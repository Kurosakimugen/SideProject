<?php

class Router 
{
    // Lista com todas as rotas, tem que estar protected para garantir que não é acessível por quem não deve utilizar
    protected array $routes = [];

    // Função responsável por registar uma rota
    // Definir melhor as váriaveis quando melhor entender as suas responsabilidades
    public function get(string $URL, string $action)
    {
        $this -> routes['GET'][$URL] = $action;
    }

    // Verificar se a rota existe e caso exista chamar as corretas dependências
    // Definir melhor as váriaveis quando melhor entender as suas responsabilidades
    public function dispatch(string $URL)
    {
        $method = $_SERVER['REQUEST_METHOD'];

        // Não percebi bem o que é suposto acontecer aqui
        $URL = parse_url($URL, PHP_URL_PATH);

        // Verifica que a rota existe e caso falhe enviar o erro 404
        if (!isset($this->routes[$method][$URL])) {
            die('404 - Rota não encontrada');
        }

        $action = $this->routes[$method][$URL];

        [$controller, $method] = explode('@', $action);

        require_once __DIR__ . "/../controllers/$controller.php";

        $instance = new $controller();
        $instance->$method();
    }
}
