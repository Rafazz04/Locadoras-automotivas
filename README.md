# Locadoras-automotivas

<p align="center">
<img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

## 📁 Acesso ao projeto

Fazer o clone do projeto com o comando: git clone https://github.com/Rafazz04/Locadoras-automotivas.git

## 🛠️ Pré requisitos (Para usar as funcionalidades da API)
**-Ter o Visual Studio Baixado ou VsCode**<br>
**-Ter o Sql Server eo SSMS baixado**<br>
**-Abra a pasta LocadoraCrud, e depois SqlServer**<br>
**-Abra o arquivo CriacaoDasTabelasECarga.sql no SSMS e exucute os comandos**<br>

## 🛠️ Abrir e rodar o projeto
**-Abra a pasta LocadoraCrud**<br>
**-Abra a solução do projeto LocadoraCrud.sln (Isso pelo Visual Studio)**<br>
**-Se estiver pelo VsCode abra o CMD, vá até o caminho em que fez o clone, entre na pasta Locadora crud e digite code**<br>
**-Abra o arquivo appsettings.json. e nele certifique-se de alterar a string de conexão para suas crdencias, as quais rodou os comandos do Sql**<br>
**-Com o projeto aberto abra o powershell, vá até a pasta com o arquivo LocadoraCrud.csproj e execute o comando dotnet watch run**<br>
**-Para visualizar a UI (com a api em execução) abra outro terminal, vá até a pasta LocadoraApp e de o comando npm start**<br>

## 🔨 Funcionalidades do projeto
-``Cadastro de Locadoras, Montadoras, Modelos e Veículos:`` Post<br>
-``Listar todas as Locadoras, Montadoras, Modelos e Veículos:`` Get<br>
-``Listagem de filtros para obter relatórios:`` Get<br>
-``Lista uma única Locadoras, Montadoras, Modelos e Veículos especificados:`` GetById()<br>
-``Atualizar lista de Locadoras, Montadoras, Modelos e Veículos:`` Put<br>
-``Deletar Locadoras, Montadoras, Modelos e Veículos:`` Delete<br>

## 👨🏻‍💻 Melhorias
- ``Adicionar a tela de cadastro e atualização para Locadora, modelos, veiculos e montadoras``
- ``Melhorar UI``

## ✔️ Técnicas e Tecnologias utilizadas

- ``.Net 6.0``
- ``Enity Framework``
- ``Sql Server``
- ``Angular 16``
- ``Bootstrap``
- ``Mvc``
- ``Injeção de dependência``

