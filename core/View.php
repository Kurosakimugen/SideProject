<?php

class View
{
    public static function render(string $view, array $data = [])
    {
        extract($data);

        require __DIR__ . "/../views/{$view}.php";
    }

    public static function renderWithLayout(
        string $view,
        array $data = [],
        string $layout = 'layout/main'
    ) {
        extract($data);

        // Captura o conteúdo da view
        ob_start();
        require __DIR__ . "/../views/{$view}.php";
        $content = ob_get_clean();

        // Carrega o layout e injeta o conteúdo
        require __DIR__ . "/../views/{$layout}.php";
    }
}
