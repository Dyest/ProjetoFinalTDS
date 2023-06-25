USE delivery;

CREATE TABLE Cliente (
    IdCliente INT NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    DataNascimento DATE NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Situacao INT NOT NULL,
    Endereco_Logradouro VARCHAR(255) NULL,
    Endereco_Numero VARCHAR(10) NOT NULL,
    Endereco_Complemento VARCHAR(255) NULL,
    Endereco_Bairro VARCHAR(255) NULL,
    Endereco_Cidade VARCHAR(255) NULL,
    Endereco_Estado VARCHAR(255) NULL,
    Endereco_CEP VARCHAR(10) NOT NULL,
    Endereco_Referencia VARCHAR(255) NULL,
    PRIMARY KEY (IdCliente)
);

INSERT INTO Cliente (IdCliente, Nome, DataNascimento, CPF, Telefone, Email, Situacao, Endereco_Logradouro, Endereco_Numero, Endereco_Complemento, Endereco_Bairro, Endereco_Cidade, Endereco_Estado, Endereco_CEP, Endereco_Referencia)
VALUES (1, 'Marco', '2000-09-08', '12345678912', '15498465484', 'marco@gmail.com', 0, 'Rua Da Produção', '939', 'casa', 'Centro', 'Missal', 'PR', '85890000', 'centro');

CREATE TABLE Pedido (
    IdPedido INT NOT NULL AUTO_INCREMENT,
    DataHoraPedido DATETIME NOT NULL,
    ValorTotal DECIMAL(18, 2) NOT NULL,
    Situacao INT NOT NULL,
    IdCliente INT NOT NULL,
    Endereco_Logradouro VARCHAR(255) NULL,
    Endereco_Numero VARCHAR(10) NOT NULL,
    Endereco_Complemento VARCHAR(255) NULL,
    Endereco_Bairro VARCHAR(255) NULL,
    Endereco_Cidade VARCHAR(255) NULL,
    Endereco_Estado VARCHAR(255) NULL,
    Endereco_CEP VARCHAR(10) NOT NULL,
    Endereco_Referencia VARCHAR(255) NULL,
    ClienteModelIdCliente INT NULL,
    PRIMARY KEY (IdPedido),
    FOREIGN KEY (ClienteModelIdCliente) REFERENCES Cliente (IdCliente)
);

CREATE TABLE Produto (
    IdProduto INT NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Descricao TEXT NOT NULL,
    Preco DECIMAL(18, 2) NOT NULL,
    Estoque INT NOT NULL,
    PRIMARY KEY (IdProduto)
);

INSERT INTO Produto VALUES(29,'X - Salada','P�o Monaco, Queijo Prato, Hamburguer 100g, Maionese da Casa, Cebola, Alface, Tomate e Picles.',25.0,1);
INSERT INTO Produto VALUES(30,'X - Bacon','P�o Monaco, Queijo Prato, Hamburguer 100g, Bacon, Maionese da Casa, Cebola, Alface, Tomate e Picles.',18.0,1);
INSERT INTO Produto VALUES(31,'Coca Cola 2l','Coca Cola 2 litros geladinha',10.0,1);
INSERT INTO Produto VALUES(32,'Coca Cola 500ml','Coca Cola 500ml geladinha',5.0,1);
INSERT INTO Produto VALUES(33,'X - Frango','P�o, Fil� de Frango, Mu�arela, Alface, Tomate, Batata Palha e Milho.',26.0,1);
INSERT INTO Produto VALUES(34,'Cachorro Quente Simples','P�o, 1 Salsicha, Batata Palha, Molho de Tomate, Mostarda e Ketchup',15.0,1);
INSERT INTO Produto VALUES(35,'Cachorro Quente Completo ','P�o, 2 Salsicha, Batata Palha, Molho de Tomate, Pur� de Batata, Frango Desfiado, Mostarda e Ketchup',20.0,1);
INSERT INTO Produto VALUES(36,'Pizza de bacon','Molho, mussarela, bacon e or�gano',50.0,1);
INSERT INTO Produto VALUES(37,'Pizza de Br�colis','MOLHO, MUSSARELA E BR�COLIS REFOGADO',45.0,1);
INSERT INTO Produto VALUES(38,'Pizza Calabresa','Molho, Mu�arela, Calabresa e Or�gano',45.0,1);
INSERT INTO Produto VALUES(39,'MEIA POR��O DE BATATA','BATATA FRITA APROX 350G',30.0,1);
INSERT INTO Produto VALUES(40,'BATATA BACON E CHEDDAR','BATATA BACON E CHEDDAR APROX 500 GR',40.0,1);
INSERT INTO Produto VALUES(41,'HEINEKEN ZERO LONG NECK 330ML','HEINEKEN ZERO LONG NECK 330ML Geladinha',8.0,1);

CREATE TABLE ItemPedido (
    IdPedido INT NOT NULL,
    IdProduto INT NOT NULL,
    Quantidade DECIMAL(10, 2) NOT NULL,
    ValorUnitario DECIMAL(18, 2) NOT NULL,
    PRIMARY KEY (IdPedido, IdProduto),
    FOREIGN KEY (IdPedido) REFERENCES Pedido (IdPedido) ON DELETE CASCADE,
    FOREIGN KEY (IdProduto) REFERENCES Produto (IdProduto) ON DELETE CASCADE
);

CREATE TABLE Visitado (
    IdCliente INT NOT NULL,
    IdProduto INT NOT NULL,
    DataHora DATETIME NOT NULL,
    PRIMARY KEY (IdCliente, IdProduto),
    FOREIGN KEY (IdCliente) REFERENCES Cliente (IdCliente) ON DELETE CASCADE,
    FOREIGN KEY (IdProduto) REFERENCES Produto (IdProduto) ON DELETE CASCADE
);

CREATE TABLE Favorito (
    IdCliente INT NOT NULL,
    IdProduto INT NOT NULL,
    DataHora DATETIME NOT NULL,
    PRIMARY KEY (IdCliente, IdProduto),
    FOREIGN KEY (IdCliente) REFERENCES Cliente (IdCliente) ON DELETE CASCADE,
    FOREIGN KEY (IdProduto) REFERENCES Produto (IdProduto) ON DELETE CASCADE
);

CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` VARCHAR(150) NOT NULL,
    `ProductVersion` VARCHAR(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

INSERT INTO __EFMigrationsHistory VALUES('20230624054356_CreateDatabase','7.0.5');

CREATE INDEX IX_Favorito_IdProduto ON Favorito (IdProduto);
CREATE INDEX IX_ItemPedido_IdProduto ON ItemPedido (IdProduto);
CREATE INDEX IX_Pedido_ClienteModelIdCliente ON Pedido (ClienteModelIdCliente);
CREATE INDEX IX_Visitado_IdProduto ON Visitado (IdProduto);