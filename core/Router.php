<?php

class Router 
{
    // Lista com todas as rotas, tem que estar protected para garantir que não é acessível por quem não deve utilizar
    protected array $routes = [];

    // Função responsável por registar uma rota
    // void apenas estabelece que é uma função sem retorno
    public function get(string $path, string $controller_section): void
    {
        $this -> routes['GET'][] = [
            'path' => $path,
            'execute' => $controller_section
        ];
    }

    // Resolver a rota atual
    public function dispatch(string $url): void
    {
        // Obtem qual o metodo HTTP a ser utilizado pela Rota (aka GET, POST, etc)
        $httpMethod = $_SERVER['REQUEST_METHOD'];
        // Função que permite limpar o URL para remover qualquer query string
        // (Ex.: /lore/quests?Initial -> /lore/quests)
        $url = parse_url($url, PHP_URL_PATH);

        // Verifica que a rota existe e caso falhe enviar o erro 404
        if (!isset($this->routes[$httpMethod])) {
            die('404 - Método não suportado');
        }

        // Loop para verificar se esta rota existe
        foreach ($this->routes[$httpMethod] as $route) {

            // Converter rota em regex
            $pattern = $this->convertPathToRegex($route['path']);

            // Verificar se a URL bate com o padrão
            // Verifica se o pattern satisfaz o url e caso sim regista os argumentos no matches
            // Exemplo:
            //$pattern = "#^/lore/quests/([^/]+)/([^/]+)$#";
            //$url     = "/lore/quests/initialSaga/Awakening";
            //$matches =
            //[
            //        0 => "/lore/quests/initialSaga/Awakening",
            //        1 => "initialSaga",
            //        2 => "Awakening"
            //]
            if (preg_match($pattern, $url, $matches)) {

                // Remove o match completo
                // Serve porque no matches estaria duplicado o url que é desnecessário, mantendo assim no matches apenas a informação necessária que o controller precisa
                array_shift($matches);

                // Transforma a action em dois argumentos para ser mais fácil de utilizar os seus argumentos
                [$controller, $method] = explode('@', $route['execute']);

                // Carrega aqui o ficheiro do controller requisitado
                require_once __DIR__ . "/../controllers/{$controller}.php";

                // Cria uma instância do Controller requisitado
                $instance = new $controller();

                // Chamar o método com parâmetros dinâmicos
                // Ou seja manda invocar na instance o method com os argumentos dados pelo matches
                // Não causa problema para strings literais porque o match no fim fica vazio e assim não causa problemas
                call_user_func_array([$instance, $method], $matches);
                return;
            }
        }

        // Invoca erro caso dê problema
        die('404 - Rota não encontrada');
    }

    // Converte /lore/{saga}/{quest} em regex
    protected function convertPathToRegex(string $path): string
    {
        // Procura por todas as instâncias que estejam entre {} para as transforma em regex que permite colocar lá argumentos especificos
        $regex = preg_replace('#\{[^/]+\}#', '([^/]+)', $path);
        // Depois coloca-se a expressão entre # para sinalizar que é texto transformado em regex
        return "#^{$regex}$#";
    }
}