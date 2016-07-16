namespace Itriad.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackLogItem",
                c => new
                    {
                        BackLogItemId = c.Long(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 4000, unicode: false),
                        CriterioAceite = c.String(maxLength: 4000, unicode: false),
                        Prioridade = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        EsforcoPrevisto = c.Double(nullable: false),
                        EsforcoReal = c.Double(nullable: false),
                        ProjetoId = c.Long(nullable: false),
                        SprintId = c.Long(),
                        InicioPlanejado = c.DateTime(),
                        InicioReal = c.DateTime(),
                        FimPlanejado = c.DateTime(),
                        FimReal = c.DateTime(),
                        Projeto_ProjetoId = c.Long(),
                        Sprint_SprintId = c.Long(),
                    })
                .PrimaryKey(t => t.BackLogItemId)
                .ForeignKey("dbo.Projeto", t => t.Projeto_ProjetoId)
                .ForeignKey("dbo.Projeto", t => t.ProjetoId)
                .ForeignKey("dbo.Sprint", t => t.Sprint_SprintId)
                .ForeignKey("dbo.Sprint", t => t.SprintId)
                .Index(t => t.ProjetoId)
                .Index(t => t.SprintId)
                .Index(t => t.Projeto_ProjetoId)
                .Index(t => t.Sprint_SprintId);
            
            CreateTable(
                "dbo.Projeto",
                c => new
                    {
                        ProjetoId = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        InicioPlanejado = c.DateTime(),
                        InicialReal = c.DateTime(),
                        FimPlanejado = c.DateTime(),
                        FimReal = c.DateTime(),
                        SitProjeto = c.Int(nullable: false),
                        ClienteId = c.Long(nullable: false),
                        EmpresaId = c.Long(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                        Cliente_ClienteId = c.Long(),
                    })
                .PrimaryKey(t => t.ProjetoId)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.Nome, unique: true, name: "INDEX_NOME")
                .Index(t => t.ClienteId)
                .Index(t => t.EmpresaId)
                .Index(t => t.Cliente_ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Long(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false, maxLength: 20, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 150, unicode: false),
                        NomeFantasia = c.String(nullable: false, maxLength: 150, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .Index(t => t.Cnpj, unique: true, name: "INDEX_CNPJ")
                .Index(t => t.RazaoSocial, unique: true, name: "INDEX_RZSOC");
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        EmpresaId = c.Long(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false, maxLength: 20, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 150, unicode: false),
                        NomeFantasia = c.String(nullable: false, maxLength: 150, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpresaId)
                .Index(t => t.Cnpj, unique: true, name: "INDEX_CNPJ")
                .Index(t => t.RazaoSocial, unique: true, name: "INDEX_RZSOC");
            
            CreateTable(
                "dbo.Profissional",
                c => new
                    {
                        ProfissionalId = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        CargoId = c.Long(nullable: false),
                        EmpresaId = c.Long(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                        Cargo_CargoId = c.Long(),
                        Empresa_EmpresaId = c.Long(),
                        Time_TimeId = c.Long(),
                    })
                .PrimaryKey(t => t.ProfissionalId)
                .ForeignKey("dbo.Cargo", t => t.Cargo_CargoId)
                .ForeignKey("dbo.Cargo", t => t.CargoId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.Empresa", t => t.Empresa_EmpresaId)
                .ForeignKey("dbo.Time", t => t.Time_TimeId)
                .Index(t => t.Nome, unique: true, name: "INDEX_NOME")
                .Index(t => t.Email, unique: true, name: "INDEX_EMAIL")
                .Index(t => t.CargoId)
                .Index(t => t.EmpresaId)
                .Index(t => t.Cargo_CargoId)
                .Index(t => t.Empresa_EmpresaId)
                .Index(t => t.Time_TimeId);
            
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        CargoId = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CargoId)
                .Index(t => t.Descricao, name: "INDEX_DESCRICAO");
            
            CreateTable(
                "dbo.HistoricoTarefa",
                c => new
                    {
                        HistoricoTarefaId = c.Long(nullable: false, identity: true),
                        TarefaId = c.Long(nullable: false),
                        DataHoraInicio = c.DateTime(nullable: false),
                        DataHoraFim = c.DateTime(nullable: false),
                        EsforcoReal = c.Double(nullable: false),
                        ProfissionalId = c.Long(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                        Tarefa_TarefaId = c.Long(),
                        Profissional_ProfissionalId = c.Long(),
                    })
                .PrimaryKey(t => t.HistoricoTarefaId)
                .ForeignKey("dbo.Profissional", t => t.ProfissionalId)
                .ForeignKey("dbo.Tarefa", t => t.Tarefa_TarefaId)
                .ForeignKey("dbo.Tarefa", t => t.TarefaId)
                .ForeignKey("dbo.Profissional", t => t.Profissional_ProfissionalId)
                .Index(t => t.TarefaId)
                .Index(t => t.ProfissionalId)
                .Index(t => t.Tarefa_TarefaId)
                .Index(t => t.Profissional_ProfissionalId);
            
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        TarefaId = c.Long(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 4000, unicode: false),
                        Prioridade = c.Int(nullable: false),
                        TipoTarefaId = c.Long(nullable: false),
                        ProfissionalId = c.Long(),
                        BackLogItemId = c.Long(nullable: false),
                        EsforcoPrevisto = c.Double(),
                        EsforcoReal = c.Double(),
                        InicioPlanejado = c.DateTime(),
                        InicioReal = c.DateTime(),
                        FimPlanejado = c.DateTime(),
                        FimReal = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                        Profissional_ProfissionalId = c.Long(),
                    })
                .PrimaryKey(t => t.TarefaId)
                .ForeignKey("dbo.BackLogItem", t => t.BackLogItemId)
                .ForeignKey("dbo.Profissional", t => t.ProfissionalId)
                .ForeignKey("dbo.TipoTarefa", t => t.TipoTarefaId)
                .ForeignKey("dbo.Profissional", t => t.Profissional_ProfissionalId)
                .Index(t => t.TipoTarefaId)
                .Index(t => t.ProfissionalId)
                .Index(t => t.BackLogItemId)
                .Index(t => t.Profissional_ProfissionalId);
            
            CreateTable(
                "dbo.TipoTarefa",
                c => new
                    {
                        TipoTarefaId = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoTarefaId);
            
            CreateTable(
                "dbo.Time",
                c => new
                    {
                        TimeId = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        ProjetoId = c.Long(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                        Projeto_ProjetoId = c.Long(),
                    })
                .PrimaryKey(t => t.TimeId)
                .ForeignKey("dbo.Projeto", t => t.ProjetoId)
                .ForeignKey("dbo.Projeto", t => t.Projeto_ProjetoId)
                .Index(t => t.ProjetoId)
                .Index(t => t.Projeto_ProjetoId);
            
            CreateTable(
                "dbo.Sprint",
                c => new
                    {
                        SprintId = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        InicioPlanejado = c.DateTime(),
                        InicialReal = c.DateTime(),
                        FimPlanejado = c.DateTime(),
                        FimReal = c.DateTime(),
                        ProjetoId = c.Long(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(),
                        UsuarioCadastro = c.String(maxLength: 100, unicode: false),
                        UsuarioAtualizacao = c.String(maxLength: 100, unicode: false),
                        Operacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SprintId)
                .ForeignKey("dbo.Projeto", t => t.ProjetoId)
                .Index(t => t.ProjetoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BackLogItem", "SprintId", "dbo.Sprint");
            DropForeignKey("dbo.Sprint", "ProjetoId", "dbo.Projeto");
            DropForeignKey("dbo.BackLogItem", "Sprint_SprintId", "dbo.Sprint");
            DropForeignKey("dbo.BackLogItem", "ProjetoId", "dbo.Projeto");
            DropForeignKey("dbo.Time", "Projeto_ProjetoId", "dbo.Projeto");
            DropForeignKey("dbo.Time", "ProjetoId", "dbo.Projeto");
            DropForeignKey("dbo.Profissional", "Time_TimeId", "dbo.Time");
            DropForeignKey("dbo.Projeto", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Profissional", "Empresa_EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Tarefa", "Profissional_ProfissionalId", "dbo.Profissional");
            DropForeignKey("dbo.HistoricoTarefa", "Profissional_ProfissionalId", "dbo.Profissional");
            DropForeignKey("dbo.HistoricoTarefa", "TarefaId", "dbo.Tarefa");
            DropForeignKey("dbo.Tarefa", "TipoTarefaId", "dbo.TipoTarefa");
            DropForeignKey("dbo.Tarefa", "ProfissionalId", "dbo.Profissional");
            DropForeignKey("dbo.HistoricoTarefa", "Tarefa_TarefaId", "dbo.Tarefa");
            DropForeignKey("dbo.Tarefa", "BackLogItemId", "dbo.BackLogItem");
            DropForeignKey("dbo.HistoricoTarefa", "ProfissionalId", "dbo.Profissional");
            DropForeignKey("dbo.Profissional", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Profissional", "CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Profissional", "Cargo_CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Projeto", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Projeto", "Cliente_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.BackLogItem", "Projeto_ProjetoId", "dbo.Projeto");
            DropIndex("dbo.Sprint", new[] { "ProjetoId" });
            DropIndex("dbo.Time", new[] { "Projeto_ProjetoId" });
            DropIndex("dbo.Time", new[] { "ProjetoId" });
            DropIndex("dbo.Tarefa", new[] { "Profissional_ProfissionalId" });
            DropIndex("dbo.Tarefa", new[] { "BackLogItemId" });
            DropIndex("dbo.Tarefa", new[] { "ProfissionalId" });
            DropIndex("dbo.Tarefa", new[] { "TipoTarefaId" });
            DropIndex("dbo.HistoricoTarefa", new[] { "Profissional_ProfissionalId" });
            DropIndex("dbo.HistoricoTarefa", new[] { "Tarefa_TarefaId" });
            DropIndex("dbo.HistoricoTarefa", new[] { "ProfissionalId" });
            DropIndex("dbo.HistoricoTarefa", new[] { "TarefaId" });
            DropIndex("dbo.Cargo", "INDEX_DESCRICAO");
            DropIndex("dbo.Profissional", new[] { "Time_TimeId" });
            DropIndex("dbo.Profissional", new[] { "Empresa_EmpresaId" });
            DropIndex("dbo.Profissional", new[] { "Cargo_CargoId" });
            DropIndex("dbo.Profissional", new[] { "EmpresaId" });
            DropIndex("dbo.Profissional", new[] { "CargoId" });
            DropIndex("dbo.Profissional", "INDEX_EMAIL");
            DropIndex("dbo.Profissional", "INDEX_NOME");
            DropIndex("dbo.Empresa", "INDEX_RZSOC");
            DropIndex("dbo.Empresa", "INDEX_CNPJ");
            DropIndex("dbo.Cliente", "INDEX_RZSOC");
            DropIndex("dbo.Cliente", "INDEX_CNPJ");
            DropIndex("dbo.Projeto", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Projeto", new[] { "EmpresaId" });
            DropIndex("dbo.Projeto", new[] { "ClienteId" });
            DropIndex("dbo.Projeto", "INDEX_NOME");
            DropIndex("dbo.BackLogItem", new[] { "Sprint_SprintId" });
            DropIndex("dbo.BackLogItem", new[] { "Projeto_ProjetoId" });
            DropIndex("dbo.BackLogItem", new[] { "SprintId" });
            DropIndex("dbo.BackLogItem", new[] { "ProjetoId" });
            DropTable("dbo.Sprint");
            DropTable("dbo.Time");
            DropTable("dbo.TipoTarefa");
            DropTable("dbo.Tarefa");
            DropTable("dbo.HistoricoTarefa");
            DropTable("dbo.Cargo");
            DropTable("dbo.Profissional");
            DropTable("dbo.Empresa");
            DropTable("dbo.Cliente");
            DropTable("dbo.Projeto");
            DropTable("dbo.BackLogItem");
        }
    }
}
