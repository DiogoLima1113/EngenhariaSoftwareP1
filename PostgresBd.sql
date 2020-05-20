CREATE TABLE produtos (
    id serial PRIMARY KEY,
    descricao varchar (120) NOT NULL,
    preco float (2) NOT NULL,
    categoria varchar (90) NOT NULL 
);

CREATE TABLE usuarios (
    id varchar(32) PRIMARY KEY NOT NULL,
	accessKey varchar(32) NOT NULL,
    nome varchar (180) NOT NULL,
    cpf varchar(16) NOT NULL,
	tipo int NOT NULL
);

CREATE TABLE clientes (
    cpf varchar(16) PRIMARY KEY NOT NULL,
    nome varchar (180) NOT NULL,
	telefone varchar(16) NOT NULL
);

CREATE TABLE formaPagamento(
	id serial PRIMARY KEY,
	descricao TEXT NOT NULL
);

CREATE TABLE venda(
    id serial PRIMARY KEY,
    valorTotal float (2) NOT NULL,
    idUsuario varchar(32),
	cpfCliente varchar(16),
    idFormaPagamento int NOT NULL,
	data DATE,
    encomenda char(1) NOT NULL
);

CREATE TABLE vendaItem(
    produtoId INTEGER NOT NULL,
    vendaId INTEGER NOT NULL,
    quantidade int NOT NULL
);

CREATE TABLE comissao (
    id serial PRIMARY KEY,
    idUsuario varchar(32),
	dataInicio DATE,
	dataFim DATE,
    valor float (2)
);

INSERT INTO public.usuarios(
	id, accesskey, nome, cpf, tipo) VALUES
	('gerente', 'e10adc3949ba59abbe56e057f20f883e', 'Diogo', '12345678901', '1'),
	('caixa', 'e10adc3949ba59abbe56e057f20f883e', 'Lucas', '12345678902', '2'),
	('vendedor', 'e10adc3949ba59abbe56e057f20f883e', 'Victor', '12345678903', '0');
	



