USE [master]
GO
/****** Object:  Database [NerdStoreEnterprise]    Script Date: 05/09/2023 22:11:29 ******/
CREATE DATABASE [NerdStoreEnterprise]
GO

USE [NerdStoreEnterprise]
GO
/****** Object:  Sequence [dbo].[MySequence]    Script Date: 05/09/2023 22:11:29 ******/
CREATE SEQUENCE [dbo].[MySequence] 
 AS [int]
 START WITH 1000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [uniqueidentifier] NOT NULL,
	[PublicPlace] [varchar](200) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[Complement] [varchar](250) NULL,
	[Neighborhood] [varchar](100) NOT NULL,
	[ZipCode] [varchar](20) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
	[Quantity] [int] NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
	[Image] [varchar](100) NULL,
	[CartId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerCart]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCart](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[TotalValue] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[DiscountType] [int] NULL,
	[DiscountValue] [decimal](18, 2) NULL,
	[Percentage] [decimal](18, 2) NULL,
	[UsedVoucher] [bit] NOT NULL,
	[VoucherCode] [varchar](50) NULL,
 CONSTRAINT [PK_CustomerCart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Email] [varchar](254) NULL,
	[Cpf] [varchar](11) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductName] [varchar](250) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitValue] [decimal](18, 2) NOT NULL,
	[ProductImage] [varchar](100) NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [int] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[VoucherId] [uniqueidentifier] NULL,
	[UsedVoucher] [bit] NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[TotalValue] [decimal](18, 2) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[PublicPlace] [varchar](100) NULL,
	[Number] [varchar](100) NULL,
	[Complement] [varchar](100) NULL,
	[Neighborhood] [varchar](100) NULL,
	[ZipCode] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[PaymentType] [int] NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Active] [bit] NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[Image] [varchar](250) NOT NULL,
	[QuantityInStock] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshTokens]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshTokens](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityKeys]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityKeys](
	[Id] [uniqueidentifier] NOT NULL,
	[KeyId] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Parameters] [nvarchar](max) NULL,
	[IsRevoked] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ExpiredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_SecurityKeys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [uniqueidentifier] NOT NULL,
	[AuthorizationCode] [varchar](100) NULL,
	[CardBrand] [varchar](100) NULL,
	[TransactionDate] [datetime2](7) NULL,
	[TotalValue] [decimal](18, 2) NOT NULL,
	[TransactionCost] [decimal](18, 2) NOT NULL,
	[TransactionStatus] [int] NOT NULL,
	[TID] [varchar](100) NULL,
	[NSU] [varchar](100) NULL,
	[PaymentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 05/09/2023 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Percentage] [decimal](18, 2) NULL,
	[DiscountValue] [decimal](18, 2) NULL,
	[Quantity] [int] NOT NULL,
	[DiscountType] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[DateOfUse] [datetime2](7) NULL,
	[ValidationDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[Used] [bit] NOT NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230130233517_Initial', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230220145700_v01', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230418003010_Customers', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230622004104_Cart', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230702201741_Voucher', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230705230904_Voucher', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230712004933_orders', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230716021134_CartCascade', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230725160145_AjusteEndereco', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230731231347_Payments', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230815134342_SecKeys', N'6.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230822224258_RefreshToken', N'6.0.13')
GO
INSERT [dbo].[Addresses] ([Id], [PublicPlace], [Number], [Complement], [Neighborhood], [ZipCode], [City], [State], [CustomerId]) VALUES (N'3692f359-dcbf-453e-8053-af40b88291ae', N'Rua dos Crenaques', N'12', N'casa', N'Santa Mônica', N'31530410', N'Belo Horizonte', N'MG', N'69715b03-96e4-4cea-97c0-e52a8af7c056')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'69715b03-96e4-4cea-97c0-e52a8af7c056', N'Catalog', N'Read')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'69715b03-96e4-4cea-97c0-e52a8af7c056', N'teste@teste.com', N'TESTE@TESTE.COM', N'teste@teste.com', N'TESTE@TESTE.COM', 1, N'AQAAAAEAACcQAAAAEDh+YCaCdtVHPQeHuAKIID+52fnkmxLmBDfMvIfETQo8g66klxNSyPdMD4k0C8HVXA==', N'SSSEF2P6LGVLRJ4IVCHGCZ64IFBTTJYN', N'0ceecd63-6aa0-47af-991f-052cc554f183', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd5d7b5eb-1761-48ac-9e06-610575facd87', N'teste2@teste.com', N'TESTE2@TESTE.COM', N'teste2@teste.com', N'TESTE2@TESTE.COM', 1, N'AQAAAAEAACcQAAAAELTFhqNx3TKBA7IYWprKST4lkYOM3IFDeZ8Qur1Vsy+tKFkM1JxoGfGoZYMkbJY4IA==', N'VFWTVQIZDFPBSLF26QFKG2PFS3VDNNKD', N'638d354e-c555-4f34-8aaa-4dcc2764e2e9', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ec5baddc-1b4c-495d-bf7d-d2e5cf258162', N'leoqr18@gmail.com', N'LEOQR18@GMAIL.COM', N'leoqr18@gmail.com', N'LEOQR18@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAECh6BOZxJLPnqwJDcnr6CKQsRS4oieuZE7bAHlN84Ui7c8GDSe/hhMfPeniayXpJpA==', N'TF64KDXHDSZHAJVHG54TPM36B5QSYT5T', N'70c43453-b2c6-43d3-be96-4590f23a6870', NULL, 0, 0, CAST(N'2023-06-27T23:52:26.0157754+00:00' AS DateTimeOffset), 1, 3)
GO
INSERT [dbo].[CustomerCart] ([Id], [CustomerId], [TotalValue], [Discount], [DiscountType], [DiscountValue], [Percentage], [UsedVoucher], [VoucherCode]) VALUES (N'bcb27607-6b4d-4730-bf16-c7b2f108ca2c', N'69715b03-96e4-4cea-97c0-e52a8af7c056', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, CAST(50.00 AS Decimal(18, 2)), 1, N'50-OFF-GERAL')
GO
INSERT [dbo].[Customers] ([Id], [Name], [Email], [Cpf], [Deleted]) VALUES (N'd5d7b5eb-1761-48ac-9e06-610575facd87', N'Teste 2', N'teste2@teste.com', N'71317820096', 0)
GO
INSERT [dbo].[Customers] ([Id], [Name], [Email], [Cpf], [Deleted]) VALUES (N'ec5baddc-1b4c-495d-bf7d-d2e5cf258162', N'Leonardo', N'leoqr18@gmail.com', N'10160484677', 0)
GO
INSERT [dbo].[Customers] ([Id], [Name], [Email], [Cpf], [Deleted]) VALUES (N'69715b03-96e4-4cea-97c0-e52a8af7c056', N'Teste', N'teste@teste.com', N'57026063022', 0)
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'e095e2c4-83c7-4191-a7e8-08bf92211aaf', N'3d5e37f2-c422-4e99-a0a5-325dbb318fe6', N'7d67df76-2d4e-4a47-a11c-08eb80a9060b', N'Camiseta 4 Head', 1, CAST(50.00 AS Decimal(18, 2)), N'4head.webp')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'be7ccfa0-a850-4c32-80c4-11ae0f1e1292', N'ec747e4b-c9c6-4017-b67a-dda8163c66a9', N'6ecaaa6b-ad9f-422c-b3bb-6013ec27b4bb', N'Camiseta Debugar Preta', 5, CAST(75.00 AS Decimal(18, 2)), N'camiseta4.jpg')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'20883d44-1499-4f7d-a6cb-16a92580e830', N'c060b789-6783-44a1-99c9-ca96741e4bb7', N'78162be3-61c4-4959-89d7-5ebfb476457e', N'Caneca Batman Preta', 5, CAST(50.00 AS Decimal(18, 2)), N'caneca-Batman.jpg')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'93ff119e-d810-4d64-ba30-6cf9c4b6482b', N'3d5e37f2-c422-4e99-a0a5-325dbb318fe6', N'7d67df76-2d4e-4a47-a12c-08eb80a9060b', N'Camiseta 4 Head Branca', 1, CAST(50.00 AS Decimal(18, 2)), N'Branca 4head.webp')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'af2dcf2b-62fa-4c65-9366-8afff285b030', N'ef25bcbf-dd53-4e6a-902e-d2b49132e8a1', N'6ecaaa6b-ad9f-422c-b3bb-6013ec27c4bb', N'Camiseta Code Life Cinza', 1, CAST(30.00 AS Decimal(18, 2)), N'camiseta3.jpg')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'91b756b0-93b0-4b85-a8b1-a2f69d130162', N'c060b789-6783-44a1-99c9-ca96741e4bb7', N'7d67df76-2d4e-4a47-a19c-08eb80a9060b', N'Camiseta Code Life Preta', 5, CAST(50.00 AS Decimal(18, 2)), N'camiseta2.jpg')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'15578170-f8ba-46e1-ad20-b564d7593235', N'35a39922-6132-4692-97c8-6e7a1de136dd', N'78162be3-61c4-4959-89d7-5ebfb476427e', N'Caneca No Coffee No Code', 1, CAST(50.00 AS Decimal(18, 2)), N'caneca4.jpg')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'e0c677e6-0158-4dc2-83cb-d2fb82d29ed3', N'ec747e4b-c9c6-4017-b67a-dda8163c66a9', N'fc184e11-014c-4978-aa10-9eb5e1af369b', N'Camiseta Software Developer', 5, CAST(100.00 AS Decimal(18, 2)), N'camiseta1.jpg')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'eb11f0da-1a8a-4e36-ad7f-d934fb906497', N'ec747e4b-c9c6-4017-b67a-dda8163c66a9', N'52dd696b-0882-4a73-9525-6af55dd416a4', N'Caneca Star Bugs Coffee', 5, CAST(20.00 AS Decimal(18, 2)), N'caneca1.jpg')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Quantity], [UnitValue], [ProductImage]) VALUES (N'afdc9159-ac77-47da-aa0a-dd75949e694e', N'ef25bcbf-dd53-4e6a-902e-d2b49132e8a1', N'7d67df76-2d4e-4a47-a19c-08eb80a9060b', N'Camiseta Code Life Preta', 2, CAST(90.00 AS Decimal(18, 2)), N'camiseta2.jpg')
GO
INSERT [dbo].[Orders] ([Id], [Code], [CustomerId], [VoucherId], [UsedVoucher], [Discount], [TotalValue], [CreationDate], [OrderStatus], [PublicPlace], [Number], [Complement], [Neighborhood], [ZipCode], [City], [State]) VALUES (N'3d5e37f2-c422-4e99-a0a5-325dbb318fe6', 1027, N'69715b03-96e4-4cea-97c0-e52a8af7c056', NULL, 0, CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(N'2023-08-14T16:37:05.0640552' AS DateTime2), 2, N'Rua dos Crenaques', N'12', N'casa', N'Santa Mônica', N'31530410', N'Belo Horizonte', N'MG')
GO
INSERT [dbo].[Orders] ([Id], [Code], [CustomerId], [VoucherId], [UsedVoucher], [Discount], [TotalValue], [CreationDate], [OrderStatus], [PublicPlace], [Number], [Complement], [Neighborhood], [ZipCode], [City], [State]) VALUES (N'35a39922-6132-4692-97c8-6e7a1de136dd', 1025, N'69715b03-96e4-4cea-97c0-e52a8af7c056', NULL, 0, CAST(0.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(N'2023-08-13T21:51:00.1418640' AS DateTime2), 2, N'Rua dos Crenaques', N'12', N'casa', N'Santa Mônica', N'31530410', N'Belo Horizonte', N'MG')
GO
INSERT [dbo].[Orders] ([Id], [Code], [CustomerId], [VoucherId], [UsedVoucher], [Discount], [TotalValue], [CreationDate], [OrderStatus], [PublicPlace], [Number], [Complement], [Neighborhood], [ZipCode], [City], [State]) VALUES (N'c060b789-6783-44a1-99c9-ca96741e4bb7', 1026, N'69715b03-96e4-4cea-97c0-e52a8af7c056', NULL, 0, CAST(0.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(N'2023-08-14T16:35:30.8956903' AS DateTime2), 2, N'Rua dos Crenaques', N'12', N'casa', N'Santa Mônica', N'31530410', N'Belo Horizonte', N'MG')
GO
INSERT [dbo].[Orders] ([Id], [Code], [CustomerId], [VoucherId], [UsedVoucher], [Discount], [TotalValue], [CreationDate], [OrderStatus], [PublicPlace], [Number], [Complement], [Neighborhood], [ZipCode], [City], [State]) VALUES (N'ef25bcbf-dd53-4e6a-902e-d2b49132e8a1', 1023, N'69715b03-96e4-4cea-97c0-e52a8af7c056', NULL, 0, CAST(0.00 AS Decimal(18, 2)), CAST(210.00 AS Decimal(18, 2)), CAST(N'2023-08-13T21:41:56.0177274' AS DateTime2), 5, N'Rua dos Crenaques', N'12', N'casa', N'Santa Mônica', N'31530410', N'Belo Horizonte', N'MG')
GO
INSERT [dbo].[Orders] ([Id], [Code], [CustomerId], [VoucherId], [UsedVoucher], [Discount], [TotalValue], [CreationDate], [OrderStatus], [PublicPlace], [Number], [Complement], [Neighborhood], [ZipCode], [City], [State]) VALUES (N'ec747e4b-c9c6-4017-b67a-dda8163c66a9', 1024, N'69715b03-96e4-4cea-97c0-e52a8af7c056', NULL, 0, CAST(0.00 AS Decimal(18, 2)), CAST(975.00 AS Decimal(18, 2)), CAST(N'2023-08-13T21:45:06.5238050' AS DateTime2), 5, N'Rua dos Crenaques', N'12', N'casa', N'Santa Mônica', N'31530410', N'Belo Horizonte', N'MG')
GO
INSERT [dbo].[Payments] ([Id], [OrderId], [PaymentType], [Value]) VALUES (N'5ec62e51-c89f-4aa6-be68-2b60a9992bb0', N'3d5e37f2-c422-4e99-a0a5-325dbb318fe6', 1, CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Payments] ([Id], [OrderId], [PaymentType], [Value]) VALUES (N'dc004230-a465-404f-b8ea-538f17f563f4', N'ec747e4b-c9c6-4017-b67a-dda8163c66a9', 1, CAST(975.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Payments] ([Id], [OrderId], [PaymentType], [Value]) VALUES (N'3ffaa6bf-3822-4b22-ad9a-85d7b1ee7cf7', N'c060b789-6783-44a1-99c9-ca96741e4bb7', 1, CAST(500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Payments] ([Id], [OrderId], [PaymentType], [Value]) VALUES (N'22b0819c-a57e-4a33-8061-8ba955b9e274', N'ef25bcbf-dd53-4e6a-902e-d2b49132e8a1', 1, CAST(210.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Payments] ([Id], [OrderId], [PaymentType], [Value]) VALUES (N'89260c8e-75f5-48b8-a7a6-e51114781676', N'35a39922-6132-4692-97c8-6e7a1de136dd', 1, CAST(50.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a11c-08eb80a9060b', N'Camiseta 4 Head', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'4head.webp', 4)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a12c-08eb80a9060b', N'Camiseta 4 Head Branca', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Branca 4head.webp', 4)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a13c-08eb80a9060b', N'Camiseta Tiltado', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'tiltado.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a14c-08eb80a9060b', N'Camiseta Tiltado Branca', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Branco Tiltado.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a15c-08eb80a9060b', N'Camiseta Heisenberg', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Heisenberg.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a16c-08eb80a9060b', N'Camiseta Kappa', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Kappa.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a17c-08eb80a9060b', N'Camiseta MacGyver', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'MacGyver.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a18c-08eb80a9060b', N'Camiseta Maestria', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Maestria.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a19c-08eb80a9060b', N'Camiseta Code Life Preta', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta2.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a29c-08eb80a9060b', N'Camiseta My Yoda', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'My Yoda.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a39c-08eb80a9060b', N'Camiseta Pato', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Pato.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a41c-08eb80a9060b', N'Camiseta Xavier School', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Xaviers School.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a42c-08eb80a9060b', N'Camiseta Yoda', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Yoda.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a49c-08eb80a9060b', N'Camiseta Quack', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Quack.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a59c-08eb80a9060b', N'Camiseta Rick And Morty 2', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Rick And Morty Captured.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a69c-08eb80a9060b', N'Camiseta Rick And Morty', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Rick And Morty.webp', 5)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a79c-08eb80a9060b', N'Camiseta Say My Name', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Say My Name.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a89c-08eb80a9060b', N'Camiseta Support', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'support.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'7d67df76-2d4e-4a47-a99c-08eb80a9060b', N'Camiseta Try Hard', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Tryhard.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476421e', N'Caneca Joker Wanted', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-joker Wanted.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476422e', N'Caneca Joker', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Joker.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476423e', N'Caneca Nightmare', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Nightmare.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476424e', N'Caneca Ozob', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Ozob.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476425e', N'Caneca Rick and Morty', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Rick and Morty.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476426e', N'Caneca Wonder Woman', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Wonder Woman.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476427e', N'Caneca No Coffee No Code', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca4.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476437e', N'Caneca Batman', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca1--batman.jpg', 5)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476447e', N'Caneca Vegeta', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca1-Vegeta.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476457e', N'Caneca Batman Preta', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Batman.jpg', 3)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476467e', N'Caneca Big Bang Theory', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-bbt.webp', 0)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476477e', N'Caneca Cogumelo', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-cogumelo.webp', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476487e', N'Caneca Geeks', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Geeks.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476497e', N'Caneca Ironman', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-ironman.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'6ecaaa6b-ad9f-422c-b3bb-6013ec27b4bb', N'Camiseta Debugar Preta', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(75.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta4.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'6ecaaa6b-ad9f-422c-b3bb-6013ec27c4bb', N'Camiseta Code Life Cinza', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(99.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta3.jpg', 3)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'52dd696b-0882-4a73-9525-6af55dd416a4', N'Caneca Star Bugs Coffee', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(20.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca1.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'191ddd3e-acd4-4c3b-ae74-8e473993c5da', N'Caneca Programmer Code', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(15.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca2.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'fc184e11-014c-4978-aa10-9eb5e1af369b', N'Camiseta Software Developer', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(100.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta1.jpg', 10)
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Active], [Value], [RegistrationDate], [Image], [QuantityInStock]) VALUES (N'20e08cd4-2402-4e76-a3c9-a026185b193d', N'Caneca Turn Coffee in Code', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(20.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca3.jpg', 10)
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'4ee54397-1606-486c-a209-4dd14a074024', N'teste2@teste.com', N'e4b1bf00-14b5-41bb-b956-130e04e0e718', CAST(N'2023-08-23T08:53:23.9716573' AS DateTime2))
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'9224793e-b507-4fc7-81d0-643890d2548d', N'teste@teste.com', N'079c8570-2af9-46f3-9965-5d332b59f49a', CAST(N'2023-08-27T06:01:10.0179863' AS DateTime2))
GO
INSERT [dbo].[SecurityKeys] ([Id], [KeyId], [Type], [Parameters], [IsRevoked], [CreationDate], [ExpiredAt]) VALUES (N'89b88231-868a-4793-b9f9-1dfca455ab00', N'ojZBQcKkb_CDZp_A8VHscg', N'EC', N'{"AdditionalData":{},"Alg":null,"Crv":"P-256","D":"GNsoHIp3Zpu0gcvMCM12G-lDZz4OS3ApSYsX5ehdFNE","DP":null,"DQ":null,"E":null,"K":null,"KeyId":"ojZBQcKkb_CDZp_A8VHscg","KeyOps":[],"Kid":"ojZBQcKkb_CDZp_A8VHscg","Kty":"EC","N":null,"Oth":null,"P":null,"Q":null,"QI":null,"Use":null,"X":"hBuKbfIHkFoz3-fs_uUlhznSktcHdcgIgeMQpleHBAc","X5c":[],"X5t":null,"X5tS256":null,"X5u":null,"Y":"M3I0JTIvnPXwGASU6KUK-dG-vie_SQ3oN517mBONYW0","KeySize":256,"HasPrivateKey":true,"CryptoProviderFactory":{"CryptoProviderCache":{},"CustomCryptoProvider":null,"CacheSignatureProviders":true,"SignatureProviderObjectPoolCacheSize":48}}', 0, CAST(N'2023-08-15T17:53:10.9443951' AS DateTime2), NULL)
GO
INSERT [dbo].[SecurityKeys] ([Id], [KeyId], [Type], [Parameters], [IsRevoked], [CreationDate], [ExpiredAt]) VALUES (N'22eaddd2-009f-4c37-b760-a604ebb72143', N'wg7ckMVXn9Fqo6Y88WHDOg', N'EC', N'{"AdditionalData":{},"Crv":"P-256","KeyId":"wg7ckMVXn9Fqo6Y88WHDOg","KeyOps":[],"Kid":"wg7ckMVXn9Fqo6Y88WHDOg","Kty":"EC","Use":"sig","X":"5N2u59c5FGN4mPyTI-P3xQ62EkeN9fWcByMszDeWxVU","X5c":[],"Y":"i4Sz6kPDzrQRkjhlxOn6DYjF8h1PCE5IAJ0qQO4o26M","KeySize":256,"CryptoProviderFactory":{"CryptoProviderCache":{},"CacheSignatureProviders":true,"SignatureProviderObjectPoolCacheSize":48}}', 1, CAST(N'2022-08-15T14:12:09.3624578' AS DateTime2), CAST(N'2023-08-15T17:53:10.8143014' AS DateTime2))
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'0bd5191c-bac7-4769-9612-0500dfd0e202', N'UHD1P3JGD9', N'MasterCard', CAST(N'2023-08-14T16:37:12.0762748' AS DateTime2), CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'6CTZSZZMMS', N'1VPD1R80KK', N'5ec62e51-c89f-4aa6-be68-2b60a9992bb0')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'cd8b1656-a8d5-40a9-9b43-0f8262c74638', N'EARSKHXEO4', N'MasterCard', CAST(N'2023-08-14T16:35:29.4855288' AS DateTime2), CAST(500.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), 1, N'UX6KIMJG08', N'SAUOMK04GW', N'3ffaa6bf-3822-4b22-ad9a-85d7b1ee7cf7')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'1c410a38-e636-409a-84f4-5e89dfbd5023', N'P136D24OE2', N'MasterCard', CAST(N'2023-08-14T16:37:04.9868665' AS DateTime2), CAST(100.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), 1, N'6CTZSZZMMS', N'1VPD1R80KK', N'5ec62e51-c89f-4aa6-be68-2b60a9992bb0')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'a67f54ab-b1f0-4569-951c-5ecc33439d79', N'', N'MasterCard', CAST(N'2023-08-13T22:05:00.3023032' AS DateTime2), CAST(210.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 5, N'3YMKQR4I8E', N'W9JK26K37L', N'22b0819c-a57e-4a33-8061-8ba955b9e274')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'b62d4445-fb66-453d-a772-705baacf3c7a', N'PNVP8H2IQ2', N'MasterCard', CAST(N'2023-08-14T16:35:42.8442728' AS DateTime2), CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'UX6KIMJG08', N'SAUOMK04GW', N'3ffaa6bf-3822-4b22-ad9a-85d7b1ee7cf7')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'e73cba37-7483-44fa-9695-a6e8e6a25136', N'86880J3VKP', N'MasterCard', CAST(N'2023-08-13T22:06:00.2442266' AS DateTime2), CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'DGRZ3ZPVKY', N'D8D89IAZAP', N'89260c8e-75f5-48b8-a7a6-e51114781676')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'23a6d1bc-30bd-4723-bc72-be4353f30586', N'8DM3M1VESO', N'MasterCard', CAST(N'2023-08-13T21:51:00.0477258' AS DateTime2), CAST(50.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), 1, N'DGRZ3ZPVKY', N'D8D89IAZAP', N'89260c8e-75f5-48b8-a7a6-e51114781676')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'4ffcc02f-f43a-47bb-a966-cc9b8cdad0ce', N'', N'MasterCard', CAST(N'2023-08-13T22:05:30.1861620' AS DateTime2), CAST(975.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 5, N'XJB1U46W36', N'3RHESMO8TZ', N'dc004230-a465-404f-b8ea-538f17f563f4')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'46e0f971-c820-4715-8ab8-d3c598a01c7b', N'PRAU0E03C9', N'MasterCard', CAST(N'2023-08-13T21:41:54.7188421' AS DateTime2), CAST(210.00 AS Decimal(18, 2)), CAST(6.30 AS Decimal(18, 2)), 1, N'3YMKQR4I8E', N'W9JK26K37L', N'22b0819c-a57e-4a33-8061-8ba955b9e274')
GO
INSERT [dbo].[Transactions] ([Id], [AuthorizationCode], [CardBrand], [TransactionDate], [TotalValue], [TransactionCost], [TransactionStatus], [TID], [NSU], [PaymentId]) VALUES (N'33e5f391-6404-4640-91cf-fe3deb94ccb6', N'51Y2OQLLZ1', N'MasterCard', CAST(N'2023-08-13T21:45:06.4301415' AS DateTime2), CAST(975.00 AS Decimal(18, 2)), CAST(29.25 AS Decimal(18, 2)), 1, N'XJB1U46W36', N'3RHESMO8TZ', N'dc004230-a465-404f-b8ea-538f17f563f4')
GO
INSERT [dbo].[Vouchers] ([Id], [Code], [Percentage], [DiscountValue], [Quantity], [DiscountType], [CreationDate], [DateOfUse], [ValidationDate], [Active], [Used]) VALUES (N'886e4ec3-9c62-454b-9408-3922e9ca4d7f', N'150-OFF-GERAL', NULL, CAST(150.00 AS Decimal(18, 2)), 50, 1, CAST(N'2023-07-05T21:14:57.7100000' AS DateTime2), NULL, CAST(N'2024-07-05T21:14:57.7100000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Vouchers] ([Id], [Code], [Percentage], [DiscountValue], [Quantity], [DiscountType], [CreationDate], [DateOfUse], [ValidationDate], [Active], [Used]) VALUES (N'768ba3d6-893f-4724-bddd-807ec88c1668', N'10-OFF-GERAL', CAST(10.00 AS Decimal(18, 2)), NULL, 48, 0, CAST(N'2023-07-05T21:14:57.7100000' AS DateTime2), NULL, CAST(N'2024-07-05T21:14:57.7100000' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Vouchers] ([Id], [Code], [Percentage], [DiscountValue], [Quantity], [DiscountType], [CreationDate], [DateOfUse], [ValidationDate], [Active], [Used]) VALUES (N'66cb079e-0d2f-4f58-bf4b-a86e71c6f7c7', N'50-OFF-GERAL', CAST(50.00 AS Decimal(18, 2)), NULL, 45, 0, CAST(N'2023-07-05T21:14:57.7100000' AS DateTime2), NULL, CAST(N'2024-07-05T21:14:57.7100000' AS DateTime2), 1, 0)
GO
/****** Object:  Index [IX_Addresses_CustomerId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Addresses_CustomerId] ON [dbo].[Addresses]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 05/09/2023 22:11:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 05/09/2023 22:11:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartItems_CartId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_CartItems_CartId] ON [dbo].[CartItems]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Customer]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IDX_Customer] ON [dbo].[CustomerCart]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_VoucherId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_VoucherId] ON [dbo].[Orders]
(
	[VoucherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_PaymentId]    Script Date: 05/09/2023 22:11:29 ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_PaymentId] ON [dbo].[Transactions]
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerCart] ADD  DEFAULT ((0.0)) FOR [Discount]
GO
ALTER TABLE [dbo].[CustomerCart] ADD  DEFAULT (CONVERT([bit],(0))) FOR [UsedVoucher]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NEXT VALUE FOR [MySequence]) FOR [Code]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Customers_CustomerId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
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
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_CustomerCart_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[CustomerCart] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_CustomerCart_CartId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Vouchers_VoucherId] FOREIGN KEY([VoucherId])
REFERENCES [dbo].[Vouchers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Vouchers_VoucherId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Payments_PaymentId] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Payments_PaymentId]
GO
USE [master]
GO
ALTER DATABASE [NerdStoreEnterprise] SET  READ_WRITE 
GO
