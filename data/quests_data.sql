-- Limpar dados para não gerar duplicados nos testes
DELETE FROM Quests;
DELETE FROM Sagas;

INSERT INTO Sagas (Display, URL_Piece) VALUES
('Awakening','awakening'),
('The War Within Saga','inside-war-saga'),
('The New War Saga','new-war-saga'),
('The Void War Saga','void-war-saga');

INSERT INTO Quests (Saga_ID, Display, URL_Piece, Tipo) VALUES
(
    (SELECT ID FROM Sagas WHERE Display = 'Awakening'),
    'The Awakening',
    'the-awakening',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'Awakening'),
    "Vor's Prize",
    'vors-prize',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'Awakening'),
    "Saya's Vigil",
    'sayas-vigil',
    'Side'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'Awakening'),
    "Vox Solaris",
    'vox-solaris',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'Awakening'),
    "Once Awake",
    'once-awake',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'Awakening'),
    "Heart of Deimos",
    'heart-of-deimos',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'Awakening'),
    "The Archwing",
    'the-archwing',
    'Main'
),
----------------------------------------------------------
(
    (SELECT ID FROM Sagas WHERE Display = 'The War Within Saga'),
    "Natah",
    'natah',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The War Within Saga'),
    "The Second Dream",
    'second-dream',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The War Within Saga'),
    "Rising Tide",
    'rising-tide',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The War Within Saga'),
    "The War Within",
    'inside-war',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The War Within Saga'),
    "Chains of Harrow",
    'harrow-chains',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The War Within Saga'),
    "Apostasy Prologue",
    'apostasy-prologue',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The War Within Saga'),
    "The Sacrifice",
    'sacrifice',
    'Main'
),
----------------------------------------------------------------
(
    (SELECT ID FROM Sagas WHERE Display = 'The New War Saga'),
    "Prelude to War",
    'prelude',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The New War Saga'),
    "The New War",
    'new-war',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The New War Saga'),
    "The Duviri Paradox",
    'duviri-paradox',
    'Main'
),
------------------------------------------------------------------
(
    (SELECT ID FROM Sagas WHERE Display = 'The Void War Saga'),
    "Whispers in the Walls",
    'whispers',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The Void War Saga'),
    "The Lotus Eaters",
    'lotus-eater',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The Void War Saga'),
    "The Hex",
    'hex',
    'Main'
),
(
    (SELECT ID FROM Sagas WHERE Display = 'The Void War Saga'),
    "The Old Peace",
    'old-peace',
    'Main'
);