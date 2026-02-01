<?php ob_start(); ?>

<h1>Warframe Weapon Builder</h1>

<?php
$content = ob_get_clean();
require __DIR__ . '/layout/main.php';
