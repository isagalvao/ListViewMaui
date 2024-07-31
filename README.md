# 📱 App

Aplicativo desenvolvido com .NET MAUI para gerenciar uma lista de contatos. A aplicação permite adicionar, visualizar, editar e excluir contatos, armazenando informações básicas como Nome, Telefone e CPF.

## 🌟 Funcionalidades

1. **📋 Lista de Contatos**:
   - Exibição de uma lista de contatos usando um `CollectionView`.
   - Cada item na lista contém os campos: **Nome** e **Telefone**.

2. **📝 Cadastro de Contato**:
   - Um botão na tela principal direciona para uma tela de cadastro.
   - A tela de cadastro contém um formulário com os campos: **Nome**, **Telefone** e **CPF**.

3. **🔍 Detalhes do Contato**:
   - Ao clicar em um item da lista, uma tela de detalhes é exibida com os campos: **Nome**, **Telefone** e **CPF**.
   - Opções para **editar** ou **excluir** o contato são disponibilizadas.

## 🏗️ Estrutura do Projeto

- **🖥️ Views**: Contém as páginas da interface de usuário.
  - `MainPage`: Tela principal com a lista de contatos e botão de cadastro.
  - `UserRegistrationPage`: Tela para inserir ou editar um contato.
  - `DetailsPage`: Tela para exibir os detalhes do contato selecionado.

- **💡 ViewModels**: Contém a lógica de apresentação.
  - `MainViewModel`: Gerencia a lista de contatos e as ações da tela principal.
  - `UserRegistrationPageViewModel`: Gerencia o processo de inserção e edição de contatos.
  - `DetailsViewModel`: Gerencia a exibição e manipulação dos detalhes de um contato.

- **🗂️ Models**: Define a estrutura de dados do aplicativo.
  - `User`: Classe representando um contato com os campos `Nome`, `Telefone` e `CPF`.

- **🔧 Services**: Gerencia a lógica de negócios e dados.
  - `ListUserRepository`: Serviço para gerenciar a lista de contatos.
  - `Navigate`: Serviço para gerenciar as navegações.

## 🚀 Como Executar

1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/isagalvao/ListViewMaui
   cd ContatoApp
2. **🏃 Execute o Projeto**:
   ```bash
    dotnet build
    dotnet run
   
## 🖼️ Imagens do Projeto

<div style="display: flex; flex-wrap: wrap; justify-content: space-between;">

  <img src="\ListViewMaui/Resources/Images/EmptyList.png" alt="Tela de Lista Vazia" width="45%">
  <img src="\ListViewMaui/Resources/Images/Register.png" alt="Tela de Registro" width="45%">

  <img src="\ListViewMaui/Resources/Images/List.png" alt="Tela de Lista" width="45%">
  <img src="\ListViewMaui/Resources/Images/Update.png" alt="Tela de Atualização" width="45%">

</div>
