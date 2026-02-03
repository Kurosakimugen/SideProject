<?php

require_once __DIR__ . '/../core/Controller.php';

class PlaceholderController extends Controller
{
    public function index()
    {
        $this->view('under-development', [
            'title' => 'Under Development'
        ]);
    }
}