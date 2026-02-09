<?php

// Adicionar o resto das quests não relacionadas com a história

return [

    // Awakening Saga (Verificar se a quest relacionada com o tutorial Awakening deve ou não ser incluida aqui, ou se tem uma categoria separada)
    'awakening' => [                                    // Nome da saga na base de dados
        'name' => 'Awakening' ,                         // Nome da Saga para ser displayed
        'quests' => [
            'the-awakening' => [                        // Nome da quest na base de dados
                'name' => 'The Awakening'               // Nome da quest para ser displayed
            ],
            'vors-prize' => [
                'name' => "Vor's Prize"
            ],
            'sayas-vigil' => [
                'name' => "Saya's Vigil"
            ],
            'vox-solaris' => [
                'name' => "Vox Solaris"
            ],
            'once-awake' => [
                'name' => "Once Awake"
            ],
            'heart-of-deimos' => [
                'name' => "Heart of Deimos"
            ],
            'the-archwing' => [
                'name' => "The Archwing"
            ]
        ]
    ],

    // War Within Saga
    'inside-war-saga' => [
        'name' => 'The War Within Saga',
        'quests' => [
            'natah' => [
                'name' => 'Natah'
            ],
            'second-dream' => [
                'name' => 'The Second Dream'
            ],
            'rising-tide' => [
                'name' => 'Rising Tide'
            ],
            'inside-war' => [
                'name' => 'The War Within'
            ],
            'harrow-chains' => [
                'name' => 'Chains of Harrow'
            ],
            'apostasy-prologue' => [
                'name' => 'Apostasy Prologue'
            ],
            'sacrifice' => [
                'name' => 'The Sacrifice'
            ]
        ]
    ],

    // New War Saga
    'new-war-saga' => [
        'name' => 'The New War Saga',
        'quests' => [
            'prelude' => [
                'name' => 'Prelude to War'
            ],
            'new-war' => [
                'name' => 'The New War'
            ],
            'duviri-paradox' => [
                'name' => 'The Duviri Paradox'
            ]
        ]
    ],

    // Void War Saga (Verificar se Old Peace pertence a esta saga ou se vai ser o começo de uma nova saga)
    'void-war-saga' => [
        'name' => 'The Void War Saga',
        'quests' => [
            'whispers' => [
                'name' => 'Whispers in the Walls'
            ],
            'lotus-eater' => [
                'name' => 'The Lotus Eaters'
            ],
            'hex' => [
                'name' => 'The Hex'
            ],
            'old-peace' => [
                'name' => 'The Old Peace'
            ]
        ]
    ]
];