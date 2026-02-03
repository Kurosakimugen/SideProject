<?php

require_once __DIR__ . '/View.php';

class Controller
{
    protected function view(
        string $view,
        array $data = [],
        string $layout = 'layout/main'
    ) {
        View::renderWithLayout($view, $data, $layout);
    }
}