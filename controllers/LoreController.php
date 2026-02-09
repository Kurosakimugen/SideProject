<?php

require_once __DIR__ . '/../core/Controller.php';

class LoreController extends Controller
{
    // path /lore
    public function index()
    {
        $this->view('lore/index',['title' => 'Lore']);
    }

    // path lore/timeline
    public function Timeline_index()
    {
        $this->view('lore/timeline',['title' => 'Timeline Lore']);
    }

    // path/quests
    public function Quests_index()
    {
        $sagas = require __DIR__ . '/../data/quests.php';

        $this->view('lore/quests/index', [
            'title' => 'Quests Lore',
            'sagas' => $sagas
        ]);
    }

    // /lore/quests/{saga}/{quest}
    public function quest(string $saga, string $quest)
    {
        $this->view('lore/quests/quest', [
            'title' => ucfirst($quest),
            'saga'  => $saga,
            'quest' => $quest
        ]);
    }
}