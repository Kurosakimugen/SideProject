DROP TABLE IF EXISTS Quests;
DROP TABLE IF EXISTS Sagas;

CREATE TABLE Sagas (
    ID INT AUTO_INCREMENT PRIMARY KEY,                      -- ID interno da saga
    Display VARCHAR(100) NOT NULL,                          -- Nome a ser mostrado no site
    URL_Piece VARCHAR(150) NOT NULL UNIQUE                  -- Nome a ser utilizado na gestão do URL
);

CREATE TABLE Quests (
    ID INT AUTO_INCREMENT PRIMARY KEY,                      -- ID Interno da Quest
    Saga_ID INT NOT NULL,                                   -- ID Interno da Saga (Vai buscar o id da tabela das Sagas)
    Display VARCHAR(100) NOT NULL,                          -- Nome a ser mostrado no site
    URL_Piece VARCHAR(150) NOT NULL ,                       -- Nome a ser utilizado na gestão do URL
    Tipo ENUM('Main','Warframe','Side') DEFAULT 'Main',     -- Classificação da quest segundo o grupo que se encaixa

    FOREIGN KEY (Saga_ID) REFERENCES Sagas(ID)
);