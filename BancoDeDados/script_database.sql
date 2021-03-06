USE [master]
GO

CREATE DATABASE [bd_cinema]

GO
ALTER DATABASE [bd_cinema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bd_cinema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bd_cinema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bd_cinema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bd_cinema] SET ARITHABORT OFF 
GO
ALTER DATABASE [bd_cinema] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [bd_cinema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bd_cinema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bd_cinema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bd_cinema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bd_cinema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bd_cinema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bd_cinema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bd_cinema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bd_cinema] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bd_cinema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bd_cinema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bd_cinema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bd_cinema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bd_cinema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bd_cinema] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [bd_cinema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bd_cinema] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bd_cinema] SET  MULTI_USER 
GO
ALTER DATABASE [bd_cinema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bd_cinema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bd_cinema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bd_cinema] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [bd_cinema] SET DELAYED_DURABILITY = DISABLED 
GO
USE [bd_cinema]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Nome] [nvarchar](256) NULL,
	[CPF] [varchar](20) NULL,
	[DataNascimento] [date] NULL,
	[Telefone] [varchar](20) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[UsuarioAtivo] [bit] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SecurityToken]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SecurityToken](
	[IdSecurityToken] [nvarchar](450) NOT NULL,
	[Authenticated] [varchar](5) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Expiration] [datetime] NOT NULL,
	[AccessToken] [nvarchar](max) NOT NULL,
	[RefreshToken] [nvarchar](450) NOT NULL,
	[Message] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TB_SECURITYTOKEN] PRIMARY KEY CLUSTERED 
(
	[IdSecurityToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_filme]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_filme](
	[IdFilme] [varchar](450) NOT NULL,
	[Titulo] [varchar](150) NOT NULL,
	[Descricao] [varchar](800) NULL,
	[Imagem] [varchar](455) NULL,
	[Caminho] [varchar](350) NULL,
	[Duracao] [varchar](5) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[IdUsuario] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_tb_filme] PRIMARY KEY CLUSTERED 
(
	[IdFilme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_sala]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_sala](
	[IdSala] [varchar](450) NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[QuantidadeAssento] [int] NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[IdUsuario] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_tb_sala] PRIMARY KEY CLUSTERED 
(
	[IdSala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_sessao]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_sessao](
	[IdSessao] [varchar](450) NOT NULL,
	[DataSessao] [date] NOT NULL,
	[HoraInicioSessao] [varchar](5) NOT NULL,
	[HoraFimSessao] [varchar](5) NOT NULL,
	[ValorIngresso] [float] NOT NULL,
	[TipoAnimacao] [varchar](2) NOT NULL,
	[TipoAudio] [varchar](8) NOT NULL,
	[DataRegistro] [datetime] NOT NULL,
	[Ativo] [bit] NULL,
	[IdUsuario] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_tb_sessao] PRIMARY KEY CLUSTERED 
(
	[IdSessao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_sessao_filme]    Script Date: 18/05/2021 00:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_sessao_filme](
	[IdFilmeSessao] [varchar](450) NOT NULL,
	[IdFilme] [varchar](450) NULL,
	[IdSala] [varchar](450) NULL,
	[IdSessao] [varchar](450) NULL,
 CONSTRAINT [PK_tb_sessao_filme] PRIMARY KEY CLUSTERED 
(
	[IdFilmeSessao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'4cc1b73d-1a1a-417a-ad32-1e7d43ed08bb', N'071cbf6e-b28d-41a8-9ddb-d7382b6ea2a8', N'ADM', N'ADM')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'7d5a642f-478d-4d1f-97e7-44b175e87b7a', N'9d31ddab-8d50-4d9f-8ca9-3956ae423662', N'Deposito', N'DEPOSITO')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'985b2caa-4da1-4c1a-9c05-da6e027d8c15', N'f0f1797b-a12f-48f1-8744-fb440b70d686', N'Financeiro', N'FINANCEIRO')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'9b5bc3dc-d30d-4f49-bbd2-96024fa7c0bf', N'3371d18d-5b9d-4bd9-9f1b-984ee03b30ac', N'Estoque', N'ESTOQUE')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'b6945246-9405-4d1f-9515-742c887a2870', N'72993a29-93b7-4a1b-b48b-a8e1d427b3f5', N'Sistema', N'SISTEMA')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'fa1aa300-3580-4faa-b8df-cd707ab411a6', N'9b4c3363-d1e3-476d-af35-6f4ed62fcc50', N'Recepcao', N'RECEPCAO')

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c', N'b6945246-9405-4d1f-9515-742c887a2870')

INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Nome], [CPF], [DataNascimento], [Telefone], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [UsuarioAtivo]) VALUES (N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c', 0, N'f88ea4ec-c907-49cf-a4c1-dd0a382c4ae2', N'Raphael Pereira Valle', N'31602496897', CAST(N'1978-08-01' AS Date), N'1111111111', N'administrador@cine.com', 1, 1, NULL, N'administrador@cine.com', N'administrador@cine.com', N'AQAAAAEAACcQAAAAEPd9BYxMjjdF/W+i4vXc+YGGd7P2UAyNrjAybIk54snizktU2dCyuZd7Gj6QFO4bEg==', N'11988089145', 0, N'2QP6LCJXHQ7LZDHEKTFVJIRODXXGVMUA', 0, N'administrador@cine.com', 1)

INSERT [dbo].[tb_filme] ([IdFilme], [Titulo], [Descricao], [Imagem], [Caminho], [Duracao], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'4ac4219e-6a88-4045-8627-c482b1c664fd', N'Tom e Jerry - O Filme', N'Uma das rivalidades mais amadas da história é reacendida quando Jerry se muda para o melhor hotel de Nova York na véspera do "casamento do século", forçando a desesperada organizadora do evento a contratar Tom para se livrar do rato. A batalha de gato e rato que se segue ameaça destruir a carreira dela, o casamento e até o próprio hotel. Mas logo surge um problema ainda maior: um funcionário diabolicamente ambicioso conspira contra os três. Uma combinação impressionante de animação clássica e live-action, a nova aventura de Tom e Jerry na telona abre novos caminhos para os personagens icônicos e os força a fazer o impensável... trabalhar juntos para salvar o dia. Classificação indicativa Livre, contém violência fantasiosa.', N'166421b2-deb6-4e71-ae5b-75b3bdafd748.jpg', N'wwwroot\\images\\filme', N'01:40', CAST(N'2021-05-17 10:43:18.850' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_filme] ([IdFilme], [Titulo], [Descricao], [Imagem], [Caminho], [Duracao], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'537C608E-DD65-4839-ACD8-C7D5190FDED5', N'Bela Vingança', N'A trama acompanha a jovem Cassie (Carey Mulligan), que vê seu promissor futuro sendo destruído após um evento misterioso. Mas nada na vida de Cassie é apenas o que parece ser. Além de inteligente, ela leva uma vida secreta à noite e está disposta a corrigir todos os erros do passado. Classificação indicativa 16 anos. contém violência, drogas e linguagem imprópria.', N'd136e1bb-a2af-4944-a492-d3df2e3fadae.jpg', N'wwwroot\\images\\filme', N'01:50', CAST(N'2021-05-16 17:37:30.223' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_filme] ([IdFilme], [Titulo], [Descricao], [Imagem], [Caminho], [Duracao], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'601e5714-a687-4b45-87cb-3a04bb3432f6', N'teste 01', N'teste 01', N'tela_nlw02.PNG', N'wwwroot\\images\\filme', N'01:00', CAST(N'2021-05-17 12:13:42.993' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_filme] ([IdFilme], [Titulo], [Descricao], [Imagem], [Caminho], [Duracao], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'6731DD97-FF12-41B2-B87D-C257485AE6D8', N'Mulher Maravilha 1984', N'Avançando para a década de 1980, a próxima aventura da Mulher-Maravilha nos cinemas a coloca frente de dois novos inimigos: Max Lord e Mulher-Leopardo. Classificação Indicativa 12 anos, contém atos criminosos, violência fantasiosa e drogas lícitas.', N'a9a9d7ff-0d38-4bd3-aa45-142f487ce69b.jpg', N'wwwroot\\images\\filme', N'02:20', CAST(N'2020-05-07 00:00:00.000' AS DateTime), 0, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_filme] ([IdFilme], [Titulo], [Descricao], [Imagem], [Caminho], [Duracao], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'71b53e6f-8b50-4651-a562-f2b0b2767eab', N'Mundo em Caos', N'Em um futuro não muito distante, em um mundo onde as mulheres desapareceram e os homens foram afetados pelo “ruído” – uma força que deixa seus pensamentos audíveis – Todd Hewitt (Tom Holland) encontra Viola (Daisy Ridley), uma jovem misteriosa que aterrissou em seu planeta. Com Viola correndo perigo, Todd jura protegê-la e colocá-la fora de perigo. Para salvá-la, Todd terá que controlar seu “ruído”, descobrir sua própria força e desvendar todos os segredos sombrios que seu planeta e sua comunidade guardam. Classificação Indicativa 14 anos. Contém: Violência, Linguagem Imprópria.', N'1e6bd51e-93e8-43f0-8882-59d8a12ceba6.jpg', N'wwwroot\\images\\filme', N'01:15', CAST(N'2021-05-17 10:33:31.900' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_filme] ([IdFilme], [Titulo], [Descricao], [Imagem], [Caminho], [Duracao], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'8d01b5f6-6142-4ae6-9359-42eb5b79806e', N'Godzilla vs Kong', N'Lendas entram em rota de colisão em Godzilla vs. Kong, quando esses dois adversários míticos se encontram em uma batalha espetacular e histórica, que coloca o destino do mundo em jogo. Kong e seus protetores iniciam uma jornada perigosa para encontrar seu verdadeiro lar. Com eles está Jia, jovem órfã com quem Kong criou um vínculo único e sólido. Mas, inesperadamente, eles cruzam o caminho de um Godzilla enfurecido, que tem deixado atrás de si uma trilha de destruição em todo o planeta. O confronto épico entre os dois titãs - instigado por forças invisíveis - é apenas a porta de entrada do grande mistério que reside nas profundezas do núcleo da Terra. Classificação Indicativa 12 anos.', N'35742e4d-ab01-4ef5-aa04-cf47b601fa5e.jpg', N'wwwroot\\images\\filme', N'01:50', CAST(N'2021-05-17 10:33:46.670' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')

INSERT [dbo].[tb_sala] ([IdSala], [Nome], [QuantidadeAssento], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'12774187-0419-41DE-9567-E1DB64A6BD36', N'Sala 03', 100, CAST(N'2021-05-12 23:25:10.000' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sala] ([IdSala], [Nome], [QuantidadeAssento], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'57A83949-34FC-4829-ACCF-5E0CE9697F06', N'Sala 01', 50, CAST(N'2021-05-12 23:25:00.000' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sala] ([IdSala], [Nome], [QuantidadeAssento], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'C4075C6D-3B5E-45E4-8E02-8FF4E2C04E60', N'Sala 02', 74, CAST(N'2021-05-12 23:25:05.000' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')

INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'070ca962-f30b-4a04-b137-cc9840c3597c', CAST(N'2021-05-15' AS Date), N'00:35', N'03:05', 25, N'3d', N'Dublado', CAST(N'2021-05-15 00:12:17.860' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'0b1ff34b-c947-4dd6-98b7-adb41dc5177a', CAST(N'2021-05-17' AS Date), N'15:00', N'17:30', 25, N'3d', N'Original', CAST(N'2021-05-17 12:23:32.817' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'796f3d2f-27be-4844-aa28-6d845022c3f1', CAST(N'2021-10-10' AS Date), N'01:15', N'10:00', 12, N'2d', N'Dublado', CAST(N'2021-05-14 12:26:05.300' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'c951dfee-4374-4058-a47a-42631b697913', CAST(N'2021-06-10' AS Date), N'06:00', N'07:40', 12, N'3d', N'Original', CAST(N'2021-05-17 19:04:27.703' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'cca361aa-cce3-448f-b4c7-7a8d464f30ce', CAST(N'2021-06-10' AS Date), N'02:15', N'04:35', 25, N'3d', N'Dublado', CAST(N'2021-05-17 13:50:29.450' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'e29bf06e-5cb1-4ec4-8f2a-e77f5351297a', CAST(N'2021-05-16' AS Date), N'01:10', N'03:40', 52, N'3d', N'Original', CAST(N'2021-05-15 00:11:28.853' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'f3b1fd7b-1d10-4b6f-ba9c-1997921c0754', CAST(N'2021-06-10' AS Date), N'02:15', N'04:45', 25, N'2d', N'Original', CAST(N'2021-05-15 00:11:49.207' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')
INSERT [dbo].[tb_sessao] ([IdSessao], [DataSessao], [HoraInicioSessao], [HoraFimSessao], [ValorIngresso], [TipoAnimacao], [TipoAudio], [DataRegistro], [Ativo], [IdUsuario]) VALUES (N'fa61c2db-a05e-413b-89ce-95d2f86f5d41', CAST(N'2021-06-01' AS Date), N'02:15', N'10:00', 10.25, N'2d', N'Original', CAST(N'2021-05-14 16:30:02.677' AS DateTime), 1, N'5e7c17d1-2f47-4b9f-a6de-fc260a735d6c')

INSERT [dbo].[tb_sessao_filme] ([IdFilmeSessao], [IdFilme], [IdSala], [IdSessao]) VALUES (N'2111c373-deda-4157-ab94-83c6d97756f1', N'4ac4219e-6a88-4045-8627-c482b1c664fd', N'12774187-0419-41DE-9567-E1DB64A6BD36', N'0b1ff34b-c947-4dd6-98b7-adb41dc5177a')
INSERT [dbo].[tb_sessao_filme] ([IdFilmeSessao], [IdFilme], [IdSala], [IdSessao]) VALUES (N'49675b83-4d62-4dbb-89ba-139ca760129b', N'6731DD97-FF12-41B2-B87D-C257485AE6D8', N'C4075C6D-3B5E-45E4-8E02-8FF4E2C04E60', N'f3b1fd7b-1d10-4b6f-ba9c-1997921c0754')
INSERT [dbo].[tb_sessao_filme] ([IdFilmeSessao], [IdFilme], [IdSala], [IdSessao]) VALUES (N'bda4f07d-6e47-4f7e-ac02-657381c81b16', N'4ac4219e-6a88-4045-8627-c482b1c664fd', N'C4075C6D-3B5E-45E4-8E02-8FF4E2C04E60', N'c951dfee-4374-4058-a47a-42631b697913')
INSERT [dbo].[tb_sessao_filme] ([IdFilmeSessao], [IdFilme], [IdSala], [IdSessao]) VALUES (N'e378d471-49f4-4f64-a96c-3da5fdc0071d', N'537C608E-DD65-4839-ACD8-C7D5190FDED5', N'C4075C6D-3B5E-45E4-8E02-8FF4E2C04E60', N'070ca962-f30b-4a04-b137-cc9840c3597c')
INSERT [dbo].[tb_sessao_filme] ([IdFilmeSessao], [IdFilme], [IdSala], [IdSessao]) VALUES (N'ffaeb834-0f46-4272-b3e6-06f9da46d8ee', N'537C608E-DD65-4839-ACD8-C7D5190FDED5', N'57A83949-34FC-4829-ACCF-5E0CE9697F06', N'e29bf06e-5cb1-4ec4-8f2a-e77f5351297a')

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[tb_filme]  WITH NOCHECK ADD  CONSTRAINT [FK_tb_filme_AspNetUsers] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tb_filme] NOCHECK CONSTRAINT [FK_tb_filme_AspNetUsers]
GO
ALTER TABLE [dbo].[tb_sala]  WITH CHECK ADD  CONSTRAINT [FK_tb_sala_AspNetUsers] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tb_sala] CHECK CONSTRAINT [FK_tb_sala_AspNetUsers]
GO
ALTER TABLE [dbo].[tb_sessao]  WITH CHECK ADD  CONSTRAINT [FK_tb_sessao_AspNetUsers] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tb_sessao] CHECK CONSTRAINT [FK_tb_sessao_AspNetUsers]
GO
ALTER TABLE [dbo].[tb_sessao_filme]  WITH CHECK ADD  CONSTRAINT [FK_tb_sessao_filme_tb_filme] FOREIGN KEY([IdFilme])
REFERENCES [dbo].[tb_filme] ([IdFilme])
GO
ALTER TABLE [dbo].[tb_sessao_filme] CHECK CONSTRAINT [FK_tb_sessao_filme_tb_filme]
GO
ALTER TABLE [dbo].[tb_sessao_filme]  WITH CHECK ADD  CONSTRAINT [FK_tb_sessao_filme_tb_sala] FOREIGN KEY([IdSala])
REFERENCES [dbo].[tb_sala] ([IdSala])
GO
ALTER TABLE [dbo].[tb_sessao_filme] CHECK CONSTRAINT [FK_tb_sessao_filme_tb_sala]
GO
ALTER TABLE [dbo].[tb_sessao_filme]  WITH CHECK ADD  CONSTRAINT [FK_tb_sessao_filme_tb_sessao] FOREIGN KEY([IdSessao])
REFERENCES [dbo].[tb_sessao] ([IdSessao])
GO
ALTER TABLE [dbo].[tb_sessao_filme] CHECK CONSTRAINT [FK_tb_sessao_filme_tb_sessao]
GO
USE [master]
GO
ALTER DATABASE [bd_cinema] SET  READ_WRITE 
GO
