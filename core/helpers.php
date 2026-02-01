<?php

// Função que permite obter a variavel para testar se recebe o conteudo certo
if (!function_exists('dd')) {
    function dd($value)
    {
        echo '<pre>';
        var_dump($value);
        echo '</pre>';
        die();
    }
}


// Sanitiza o texto recebido
if (!function_exists('e')) {
    function e(string $value)
    {
        return htmlspecialchars($value, ENT_QUOTES, 'UTF-8');
    }
}
