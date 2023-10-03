
-- Primeiro crie o DB
CREATE DATABASE LOCADORA;
---------------------------//---------------------------//-----------------------
-- Depois crie as tables
CREATE TABLE Locadoras (
    LocadoraId INT PRIMARY KEY IDENTITY(1,1),
    NomeFantasia VARCHAR(200) NOT NULL,
    RazaoSocial VARCHAR(200) NOT NULL,
    CNPJ VARCHAR(18) NOT NULL,
    Email VARCHAR(150),
    Telefone VARCHAR(20),
	CEP VARCHAR(10),
    Rua VARCHAR(300),
    Numero VARCHAR(100),
    Bairro VARCHAR(300),
    Estado VARCHAR(100),
    Cidade VARCHAR(100)
);

CREATE TABLE Montadoras (
    MontadoraId INT PRIMARY KEY IDENTITY(1,1),
    NomeMontadora VARCHAR(200) UNIQUE NOT NULL
);

CREATE TABLE Modelos (
    ModeloId INT PRIMARY KEY IDENTITY(1,1),
    NomeModelo VARCHAR(200) NOT NULL,
    MontadoraId INT FOREIGN KEY REFERENCES Montadoras(MontadoraId),
);

CREATE TABLE Veiculos (
    VeiculoId INT PRIMARY KEY IDENTITY(1,1),
    NumeroPortas VARCHAR(10),
    ModeloId INT FOREIGN KEY REFERENCES Modelos(ModeloId),
	LocadoraId INT FOREIGN KEY REFERENCES Locadoras(LocadoraId) ON DELETE SET NULL,
    Cor VARCHAR(50),
    Fabricante VARCHAR(200),
    AnoModelo VARCHAR(20),
    AnoFabricacao VARCHAR(20),
    Placa VARCHAR(200) UNIQUE NOT NULL,
    Chassi VARCHAR(200) UNIQUE NOT NULL,
    DataCriacao DATETIME DEFAULT GETDATE(),
    UNIQUE (Placa, Chassi)
);

CREATE TABLE VeiculoLogs (
    VeiculoLogId INT PRIMARY KEY IDENTITY(1,1),
    VeiculoId INT FOREIGN KEY REFERENCES Veiculos(VeiculoId),
    NomeLocadora VARCHAR(200),
    NomeModelo VARCHAR(200),
    DataInicio DATETIME,
    DataFim DATETIME
);

---------------------------//---------------------------//-----------------------
--  Agora rode os Scripts para dar carga nas tables
INSERT INTO Locadoras (NomeFantasia, RazaoSocial, CNPJ, Email, Telefone, CEP, Rua, Numero, Bairro, Estado, Cidade) VALUES
('Unidas', 'Unidas Locações e Serviços S.A', '27544984000128', 'email@example.com', '1111111', '13700970', 'Rua 1', '10', 'Nações Unidas', 'São Paulo', 'São Paulo'),
('Localiza', 'LOCALIZA RENT A CAR SA', '16670085000155', 'email@example.com', '1111111', '12345678', 'Rua 1', '15', 'Jardim Monte Alegre', 'São Paulo', 'Taboão da Serra'),
('Moovida', 'MOVIDA LOCACAO DE VEICULOS S.A', '32936218000149', 'email@example.com', '1111111', '12540970', 'Rua 1', '100', 'Campo Limpo', 'São Paulo', 'São Paulo'),
('Locadora X', 'X Rent a Car Ltda', '12345678901234', 'email@example.com', '2222222', '04578901', 'Avenida Principal', '25', 'Centro', 'Rio de Janeiro', 'RJ'),
('Fast Cars', 'Fast Cars Locações Ltda', '98765432109876', 'email@example.com', '3333333', '56789012', 'Rua Veloz', '5', 'Velocidade Alta', 'São Paulo', 'SP'),
('AluguelTop', 'AluguelTop Locações S.A', '45678901234567', 'email@example.com', '4444444', '45678123', 'Avenida Top', '8', 'Bairro Top', 'Curitiba', 'PR'),
('RentSpeed', 'RentSpeed Aluguel de Carros Ltda', '89012345678901', 'email@example.com', '5555555', '89012345', 'Rua Rápida', '30', 'Velocidade Extrema', 'Brasília', 'DF'),
('Carros&Furiosos', 'Carros&Furiosos Locações Ltda', '34567890123456', 'email@example.com', '6666666', '98765432', 'Avenida Furiosa', '11', 'Velocidade Máxima', 'Fortaleza', 'CE'),
('TopRides', 'TopRides Locações S.A', '56789012345678', 'email@example.com', '7777777', '34567890', 'Rua Top', '22', 'Top Ville', 'Salvador', 'BA'),
('VelozAluga', 'VelozAluga Aluguel de Carros Ltda', '23456789012345', 'email@example.com', '8888888', '23456789', 'Avenida da Velocidade', '18', 'Velocidade Rápida', 'Recife', 'PE');

INSERT INTO Montadoras (NomeMontadora) VALUES
('Toyota'),
('Volkswagen'),
('Ford'),
('General Motors'),
('BMW'),
('Honda'),
('Nissan'),
('Fiat'),
('Hyundai');

INSERT INTO Modelos (NomeModelo, MontadoraId) VALUES
('Corolla', 1),
('RAV4', 1),
('Camry', 1),
('Fit', 6),
('Civic', 6),
('CR-V', 6),
('Uno', 8),
('Palio', 8),
('Strada', 8),
('Toro', 8),
('Mobi', 8);

INSERT INTO Veiculos (NumeroPortas, ModeloId, LocadoraId, Cor, Fabricante, AnoModelo, AnoFabricacao, Placa, Chassi) VALUES
('4', 1, 2, 'Azul', 'Toyota', '2022', '2020', 'ABC1234', 'XYZ987'),
('4', 2,  3, 'Vermelho', 'Toyota', '2018', '2022', 'DEF5678', 'UVW0123'),
('4', 3, 5, 'Preto', 'Toyota', '2020', '2022', 'GHI9012', 'LMN3456'),
('4', 4, 2, 'Branco', 'Honda', '2023', '2022', 'JKL2345', 'OPQ6789'),
('4', 5, 6, 'Prata', 'Honda', '2023', '2022', 'RST6789', 'XYZ1234'),
('4', 6, 3,'Azul', 'Honda', '2020', '2022', 'UVW9012', 'ABC3456'),
('4', 7, 4, 'Verde', 'Fiat', '2014', '2022', 'DEF7890', 'UVW5678'),
('4', 8, 2,'Amarelo', 'Fiat', '2015', '2022', 'GHI1234', 'LMN6789'),
('4', 9, 5,'Cinza', 'Fiat', '2021', '2022', 'JKL5678', 'OPQ9012'),
('4', 10, 6,'Marrom', 'Fiat', '2020', '2022', 'RST8901', 'XYZ2345');