# 📋 Plano de Testes Clareia

## Objetivo
Validar os principais fluxos da aplicação CLAREIA: cadastro de termos, registros de leitura, e auditoria.

## Componentes
- TermoService
- LeituraService
- Controllers
- Repositório genérico

## Casos de Teste

### ✅ Cadastro de Termo
- Entrada válida → deve salvar com sucesso
- Título vazio → deve lançar exceção
- Conteúdo vazio → deve lançar exceção

### ✅ Registro de Leitura
- Entrada válida → deve salvar com sucesso
- Leitura duplicada → deve lançar erro

### 🔐 Segurança (futuro)
- Usuário não autenticado → acesso negado
- Usuário autenticado → campos de auditoria são preenchidos
