using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Code
{
	public class Repositorio
	{
		private readonly TipoResposta tipoRespostaInteiro = new TipoResposta { Nome = "int", Type = typeof(int), Formato = "##0" };
		private readonly TipoResposta tipoRespostaDecimal = new TipoResposta { Nome = "decimal" };
		private readonly TipoResposta tipoRespostaData = new TipoResposta { Nome = "DateTime" };
		private readonly TipoResposta tipoRespostaTextoLivre = new TipoResposta { Nome = "string" };
		private readonly TipoResposta tipoRespostaSimENao = new TipoResposta
		{
			Nome = "SimENao",
			OpcoesResposta = [
				new OpcaoResposta{ Texto = "Sim", Valor = "1"  },
				new OpcaoResposta{ Texto = "Não", Valor = "0"  }
			]
		};
		private readonly TipoResposta tipoRespostaSimENaoNaoLembro = new TipoResposta
		{
			Nome = "SimENaoNaoLembro",
			OpcoesResposta = [
				new OpcaoResposta{ Texto = "Sim", Valor = "Sim"  },
				new OpcaoResposta{ Texto = "Não", Valor = "Nao"  },
				new OpcaoResposta{ Texto = "Não Lembro", Valor = "Não Lembro"  }
			]
		};
		private readonly TipoResposta tipoRespostaSimNaoTalvez = new TipoResposta
		{
			Nome = "SimNaoTalvez",
			OpcoesResposta = [
				new OpcaoResposta{ Texto = "Sim", Valor = "Sim"  },
				new OpcaoResposta{ Texto = "Não", Valor = "Nao"  },
				new OpcaoResposta{ Texto = "Talvez", Valor = "Talvez"  }
			]
		};
		public List<TipoResposta> TipoRespostas { get; } = [];
		public List<Formulario> Formularios { get; } = [];
		public List<Pergunta> FormularioPerguntas { get; } = [];
		public List<RespostaFormulario> RespostaFormularioPacientes { get; } = [];
		public List<RespostaPergunta> RespostaPacientes { get; } = [];



		public List<Configuracao> Configuracoes { get; } = [];
		public List<Profissao> Profissoes { get; } = [];
		public Configuracao Configuracao => Configuracoes.FirstOrDefault();

		public async Task Load()
		{
			Configuracoes.AddRange(Factory.CreateConfiguracao());
			Profissoes.AddRange(Factory.CreateProfissao());
			await Task.CompletedTask;

			var pergunta1 = new Pergunta { Texto = "Quando vc nasceu", TipoResposta = tipoRespostaData };
			var pergunta2 = new Pergunta { Texto = "Já fez alguma cirugia", TipoResposta = tipoRespostaSimENaoNaoLembro };
			var pergunta3 = new Pergunta { Texto = "É Fumante", TipoResposta = tipoRespostaSimENao };
			var pergunta4 = new Pergunta { Texto = "QUal o seu nome", TipoResposta = tipoRespostaTextoLivre };
			var pergunta5 = new Pergunta { Texto = "QUal sua idade", TipoResposta = tipoRespostaInteiro };
			var pergunta6 = new Pergunta { Texto = "QUal seu peso", TipoResposta = tipoRespostaDecimal };
			var pergunta7 = new Pergunta { Texto = "Teste", TipoResposta = tipoRespostaSimNaoTalvez };
			var formulario = new Formulario
			{
				Nome = "Teste",
				Ativo = true,
				Perguntas = new List<Pergunta>
				{
					pergunta1,
					pergunta2,
					pergunta3,
					pergunta4,
					pergunta5,
					pergunta6,
					pergunta7,
				}
			};

			var resposta1 = new RespostaPergunta { Pergunta = pergunta1, StringValue = "30/11/1995" };
			var resposta2 = new RespostaPergunta { Pergunta = pergunta2, StringValue = "Sim" };
			var resposta3 = new RespostaPergunta { Pergunta = pergunta3, StringValue = "Não" };
			var resposta4 = new RespostaPergunta { Pergunta = pergunta4, StringValue = "Bruno Fernandes" };
			var resposta5 = new RespostaPergunta { Pergunta = pergunta5, StringValue = "29" };
			var resposta6 = new RespostaPergunta { Pergunta = pergunta6, StringValue = "120.3" };
			var resposta7 = new RespostaPergunta { Pergunta = pergunta7, StringValue = "Talvez" };
			var respostaFormularioPaciente = new RespostaFormulario
			{
				DataResposta = DateTime.Now,
				UsuarioId = 1,
				Formulario = formulario,
				Respostas = new List<RespostaPergunta>
				{
					 resposta1,
					 resposta2,
					 resposta3,
					 resposta4,
					 resposta5,
					 resposta6,
					 resposta7,
				}
			};

			TipoRespostas.AddRange([tipoRespostaData, tipoRespostaSimENaoNaoLembro, tipoRespostaSimENao, tipoRespostaTextoLivre, tipoRespostaInteiro, tipoRespostaDecimal]);
			FormularioPerguntas.AddRange([pergunta1, pergunta2, pergunta3, pergunta4, pergunta5, pergunta6, pergunta7]);
			Formularios.AddRange([formulario]);
			RespostaFormularioPacientes.AddRange([respostaFormularioPaciente]);
			RespostaPacientes.AddRange([resposta1, resposta2, resposta3, resposta4, resposta5, resposta6, resposta7]);
		}
	}



	public class Formulario
	{
		public int Id { get; set; } // Tipo INT para o campo ID
		public string Nome { get; set; } // Tipo VARCHAR2(255) mapeado para string
		public string Descricao { get; set; } // Tipo VARCHAR2(500) mapeado para string
		public string Versao { get; set; } // Tipo VARCHAR2(10) mapeado para string
		public DateTime? DataCriacao { get; set; } // Tipo TIMESTAMP(6) mapeado para DateTime (nullable)
		public bool Ativo { get; set; } // Tipo NUMBER(1,0) mapeado para bool (1 = true, 0 = false)

		public List<Pergunta> Perguntas { get; set; }

		public RespostaFormulario Responder()
		{
			var respostaFormulario = new RespostaFormulario
			{
				DataResposta = DateTime.Now,
				UsuarioId = 1,
				Formulario = this,
			};

			var respostas = Perguntas.Select(p =>
				new RespostaPergunta { RespostaFormulario = respostaFormulario, Pergunta = p }
			);

			respostaFormulario.Respostas = respostas.ToList();

			return respostaFormulario;
		}
	}

	public class Pergunta
	{
		public int Id { get; set; } // Tipo NUMBER mapeado para INT
		[JsonIgnore]
		public Formulario Formulario { get; set; }
		public string Texto { get; set; } // Tipo VARCHAR2(500) mapeado para string
		public TipoResposta TipoResposta { get; set; } // Tipo VARCHAR2(20) mapeado para string
		public int Ordem { get; set; } // Tipo NUMBER mapeado para INT
	}

	public class TipoResposta
	{
		public int Id { get; set; }
		public string Nome { get; set; } = "Inteiro";
		public List<OpcaoResposta> OpcoesResposta { get; set; }
		public Type Type { get; internal set; }
		public string Formato { get; internal set; }
	}

	public class OpcaoResposta
	{
		public int Id { get; set; } // Tipo NUMBER mapeado para INT
		public TipoResposta TipoResposta { get; set; }
		public string Texto { get; set; } // Tipo VARCHAR2(255) mapeado para string
		public string Valor { get; set; } // Tipo VARCHAR2(10) mapeado para string
		public int Ordem { get; set; } // Tipo NUMBER mapeado para INT
	}

	public class RespostaFormulario
	{
		public int UsuarioId { get; set; } // Tipo NUMBER mapeado para INT
		[JsonIgnore]
		public Formulario Formulario { get; set; }
		public DateTime? DataResposta { get; set; } // Tipo TIMESTAMP(6) mapeado para DateTime? (nullable)
		public List<RespostaPergunta> Respostas { get; set; }
	}

	public class RespostaPergunta
	{
		public int Id { get; set; } // Tipo NUMBER mapeado para INT
		[JsonIgnore]
		public RespostaFormulario RespostaFormulario { get; set; }
		public Pergunta Pergunta { get; set; } // Tipo NUMBER mapeado para INT

		public object Value { get; set; }

		[JsonIgnore]
		public string StringValue { get => Value?.ToString(); set => Value = value; }
		[JsonIgnore]
		public int? IntValue { get => string.IsNullOrWhiteSpace(StringValue) ? default : int.Parse(StringValue); set => StringValue = value?.ToString(); }
		[JsonIgnore]
		public decimal? DecimalValue { get => string.IsNullOrWhiteSpace(StringValue) ? default : decimal.Parse(StringValue); set => StringValue = value?.ToString(); }
		[JsonIgnore]
		public DateTime? DateTimeValue { get => Value == null ? null : Convert.ToDateTime(Value); set => Value = value?.ToString(); }
		[JsonIgnore]
		public bool? BoolValue { get => string.IsNullOrWhiteSpace(StringValue) ? default : bool.Parse(StringValue); set => StringValue = value?.ToString(); }
	}
}