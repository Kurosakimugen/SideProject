<?php

// Rota inicial que reencaminha o user para a main page
// Falta desenvolver o controlador propriamente, como entender melhor o primeiro argumento
$router->get('/', 'HomeController@index');

// Rotas de Placeholder referente a mudar para a página respectiva
$router->get('/builder', 'PlaceholderController@index');
$router->get('/builds', 'PlaceholderController@index');

// Rotas de Lore
$router->get('/lore', 'LoreController@index');
$router->get('/lore/timeline', 'LoreController@Timeline_index');
$router->get('/lore/quests', 'LoreController@Quests_index');
$router->get('/lore/quests/{saga}/{quest}', 'LoreController@quest');