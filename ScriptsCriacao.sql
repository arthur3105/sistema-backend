-- 1 - CRIAR O BANCO
CREATE DATABASE programacao_do_zero;

-- 2 - USAR O BANCO
USE programacao_do_zero;

-- 3 - CRIAR TABELA USUÁRIO
CREATE TABLE usuario(
    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    sobrenome VARCHAR(150) NOT NULL,
    email VARCHAR(50) NOT NULL,
    telefone VARCHAR(15) NOT NULL,
    genero VARCHAR(20) NOT NULL,
    senha VARCHAR(30) NOT NULL,
    PRIMARY KEY(id)
);

-- 4 - CRIAR A TABELA ENDEREÇO
CREATE TABLE endereco(
    id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(200) NOT NULL,
    numero VARCHAR(20) NOT NULL,
    bairro VARCHAR(200) NOT NULL,
    complemento VARCHAR(200) NULL,
    cidade VARCHAR(200) NOT NULL,
    estado VARCHAR(2) NULL,
    cep VARCHAR(9) NOT NULL,
    PRIMARY KEY(id)
);

-- 5 - ALTERAR TABELA ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- 6 -INSERIR USUÁRIOS
INSERT INTO usuario
(nome, sobrenome, telefone, email, genero, senha)
VALUES
('Renato','Gava','renatogava@live.com','(11)99532-4543','Masculino','123')

INSERT INTO usuario
(nome, sobrenome, email, telefone, genero, senha)
VALUES
('Gustavo','Gomes','gustavo@gmail.com','(85)98645-5876','Masculino','789')

-- 7 -SELECIONAR TODOS OS USUÁRIOS
SELECT * FROM usuario;

-- 8 -SELECIONAR UM USUÁRIO ESPECÍFICO
SELECT * FROM usuario WHERE email = 'renatogava2@live.com';

-- 9 -ALTERAR USUÁRIO
UPDATE usuario SET email = 'gustavoaugusto@hotmail.com' WHERE id = 3;

-- 10 -EXCLUIR USUÁRIO
DELETE FROM usuario WHERE id = 2;