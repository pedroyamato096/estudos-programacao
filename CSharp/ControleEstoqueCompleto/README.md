# Controle de Estoque Completo

Projeto acadêmico em C# criado a partir da união de exercícios sobre cadastro de produtos, persistência em arquivo e controle de níveis de estoque.

## Funcionalidades

- Cadastro de produtos
- Validação de entradas
- Listagem dos produtos cadastrados
- Registro de vendas
- Controle de estoque mínimo e máximo
- Persistência dos dados em arquivo `.txt`
- Tratamento de erros na leitura e gravação do arquivo

## Estrutura

```text
ControleEstoqueCompleto/
├── Models/
│   └── Produto.cs
├── Util/
│   ├── ArquivoEstoque.cs
│   └── Entrada.cs
├── Dados/
├── Program.cs
├── ControleEstoqueCompleto.csproj
└── README.md
```

## Conceitos praticados

- Programação orientada a objetos
- Encapsulamento
- Métodos e propriedades
- Listas (`List<T>`)
- Estruturas de repetição e decisão
- Tratamento de exceções com `try/catch`
- Manipulação de arquivos com `StreamReader` e `StreamWriter`
