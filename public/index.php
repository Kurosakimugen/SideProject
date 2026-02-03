<?php

require_once __DIR__ . '/../core/Router.php';
require_once __DIR__ . '/../core/helpers.php';

$router = new Router();

// Carregar rotas
require_once __DIR__ . '/../routes/web.php';

// Executar rota atual
$router->dispatch($_SERVER['REQUEST_URI']);
