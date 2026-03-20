
USE [RentACar]
GO
/****** Object:  Table [dbo].[Automobil]    Script Date: 20/03/2026 16:28:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Automobil](
	[AutomobilID] [int] IDENTITY(1,1) NOT NULL,
	[RegistarskiBroj] [varchar](50) NOT NULL,
	[Marka] [varchar](20) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Godiste] [int] NOT NULL,
	[Kilometraza] [int] NOT NULL,
	[KlasaID] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Automobil] PRIMARY KEY CLUSTERED 
(
	[AutomobilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iznajmljivanje]    Script Date: 20/03/2026 16:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iznajmljivanje](
	[IznajmljivanjeID] [int] IDENTITY(1,1) NOT NULL,
	[statusIznajmljivanja] [varchar](50) NOT NULL,
	[Popust] [int] NOT NULL,
	[UkupnaCena] [decimal](8, 2) NOT NULL,
	[DatumKreiranja] [date] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[RadnikID] [int] NOT NULL,
 CONSTRAINT [PK_Iznajmljivanje] PRIMARY KEY CLUSTERED 
(
	[IznajmljivanjeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KlasaVozila]    Script Date: 20/03/2026 16:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KlasaVozila](
	[KlasaID] [int] NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
	[OsnovnaCenaPoDanu] [int] NOT NULL,
 CONSTRAINT [PK_KlasaVozila] PRIMARY KEY CLUSTERED 
(
	[KlasaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 20/03/2026 16:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[KorisnikID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[Adresa] [varchar](50) NOT NULL,
	[MestoID] [int] NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesto]    Script Date: 20/03/2026 16:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesto](
	[MestoID] [int] NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Mesto] PRIMARY KEY CLUSTERED 
(
	[MestoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Radnik]    Script Date: 20/03/2026 16:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Radnik](
	[RadnikID] [int] NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[KorisnickoIme] [varchar](50) NOT NULL,
	[Sifra] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Radnik] PRIMARY KEY CLUSTERED 
(
	[RadnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaIznajmljivanja]    Script Date: 20/03/2026 16:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaIznajmljivanja](
	[IznajmljivanjeID] [int] NOT NULL,
	[RBr] [int] NOT NULL,
	[DatumOd] [date] NOT NULL,
	[DatumDo] [date] NULL,
	[PocetnaKM] [int] NOT NULL,
	[ZavrsnaKM] [int] NULL,
	[CenaPoDanu] [int] NOT NULL,
	[UkupnaCenaStavke] [int] NOT NULL,
	[StatusStavke] [varchar](50) NOT NULL,
	[AutomobilID] [int] NOT NULL,
 CONSTRAINT [PK_StavkaIzdavanja] PRIMARY KEY CLUSTERED 
(
	[IznajmljivanjeID] ASC,
	[RBr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Automobil] ON 

INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (1, N'bg1111rs', N'porshe', N'911', 2024, 64000, 1, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (3, N'bg333rs', N'mazda', N'6', 2024, 1234, 3, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (4, N'bg444rs', N'golf', N'7', 2020, 102000, 4, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (5, N'bg555rs', N'smart', N'forfour', 2021, 151000, 5, N'nedostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (11, N'BG777RS', N'alfa', N'147', 1999, 500000, 1, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (25, N'ac123aa', N'Mazda', N'6', 2020, 28000, 1, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (1020, N'BG456RS', N'Lada', N'niva', 2010, 54000, 2, N'nedostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (1023, N'BG552RS', N'mazda', N'rx7', 2010, 127000, 1, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (1025, N'bg787rs', N'renault', N'megane', 2015, 245000, 4, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (1028, N'bg666rs', N'peugeot', N'208', 2017, 250000, 5, N'dostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (1029, N'bg222rs', N'toyota', N'yaris', 2019, 255000, 5, N'nedostupan')
INSERT [dbo].[Automobil] ([AutomobilID], [RegistarskiBroj], [Marka], [Model], [Godiste], [Kilometraza], [KlasaID], [status]) VALUES (1031, N'bg888rs', N'suzuki', N'swift', 2017, 278000, 4, N'nedostupan')
SET IDENTITY_INSERT [dbo].[Automobil] OFF
GO
SET IDENTITY_INSERT [dbo].[Iznajmljivanje] ON 

INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeID], [statusIznajmljivanja], [Popust], [UkupnaCena], [DatumKreiranja], [KorisnikID], [RadnikID]) VALUES (1015, N'aktivno', 5, CAST(1007.00 AS Decimal(8, 2)), CAST(N'2026-03-19' AS Date), 2, 1)
INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeID], [statusIznajmljivanja], [Popust], [UkupnaCena], [DatumKreiranja], [KorisnikID], [RadnikID]) VALUES (1019, N'zavrseno', 10, CAST(108.00 AS Decimal(8, 2)), CAST(N'2026-03-19' AS Date), 1, 1)
INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeID], [statusIznajmljivanja], [Popust], [UkupnaCena], [DatumKreiranja], [KorisnikID], [RadnikID]) VALUES (1021, N'aktivno', 10, CAST(1026.00 AS Decimal(8, 2)), CAST(N'2026-03-20' AS Date), 1, 1)
INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeID], [statusIznajmljivanja], [Popust], [UkupnaCena], [DatumKreiranja], [KorisnikID], [RadnikID]) VALUES (1022, N'aktivno', 10, CAST(54.00 AS Decimal(8, 2)), CAST(N'2026-03-20' AS Date), 1, 1)
INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeID], [statusIznajmljivanja], [Popust], [UkupnaCena], [DatumKreiranja], [KorisnikID], [RadnikID]) VALUES (1023, N'aktivno', 10, CAST(540.00 AS Decimal(8, 2)), CAST(N'2026-03-20' AS Date), 1, 2)
SET IDENTITY_INSERT [dbo].[Iznajmljivanje] OFF
GO
INSERT [dbo].[KlasaVozila] ([KlasaID], [Naziv], [OsnovnaCenaPoDanu]) VALUES (1, N'Lux', 500)
INSERT [dbo].[KlasaVozila] ([KlasaID], [Naziv], [OsnovnaCenaPoDanu]) VALUES (2, N'Suv', 300)
INSERT [dbo].[KlasaVozila] ([KlasaID], [Naziv], [OsnovnaCenaPoDanu]) VALUES (3, N'Limuzina', 180)
INSERT [dbo].[KlasaVozila] ([KlasaID], [Naziv], [OsnovnaCenaPoDanu]) VALUES (4, N'Gradski', 70)
INSERT [dbo].[KlasaVozila] ([KlasaID], [Naziv], [OsnovnaCenaPoDanu]) VALUES (5, N'Ekonomic', 30)
GO
SET IDENTITY_INSERT [dbo].[Korisnik] ON 

INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (1, N'Mica', N'Micic', N'mica@gmail', N'presernova', 5)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (2, N'Maka', N'Makic', N'maka@gmail', N'glavasova', 5)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (3, N'Steva', N'Stevic', N'steka@gmail', N'prvomajska', 6)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (4, N'Vuk', N'Vukic', N'vuk@gmail', N'fontana', 2)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (5, N'Dzoni', N'Dzon', N'džoni@gmail', N'mika', 4)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (6, N'Joka', N'Jokic', N'joka@gmail', N'ljuba', 1)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (7, N'neki', N'lik', N'bg fon', N'nekilik@gmail.com', 2)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (8, N'Marko', N'Markovic', N'ustanicka', N'marko@gmail.com', 2)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (9, N'aa', N'a', N'a', N'marko@gmailcom', 3)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (10, N'asd', N'asd', N'asd', N'marko@gmail.com', 1)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (11, N'aa', N'a', N'a', N'a', 1)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (12, N'asd', N'sd', N'marko@gmail.com', N'sd', 1)
INSERT [dbo].[Korisnik] ([KorisnikID], [Ime], [Prezime], [email], [Adresa], [MestoID]) VALUES (13, N'asda', N'asd', N'asd', N'marko@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Korisnik] OFF
GO
INSERT [dbo].[Mesto] ([MestoID], [Naziv]) VALUES (1, N'Novi Sad')
INSERT [dbo].[Mesto] ([MestoID], [Naziv]) VALUES (2, N'Beograd')
INSERT [dbo].[Mesto] ([MestoID], [Naziv]) VALUES (3, N'Subotica')
INSERT [dbo].[Mesto] ([MestoID], [Naziv]) VALUES (4, N'Kragujevac')
INSERT [dbo].[Mesto] ([MestoID], [Naziv]) VALUES (5, N'Nis')
INSERT [dbo].[Mesto] ([MestoID], [Naziv]) VALUES (6, N'Leskovac')
GO
INSERT [dbo].[Radnik] ([RadnikID], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (1, N'Uros', N'Uros', N'uca', N'12345678')
INSERT [dbo].[Radnik] ([RadnikID], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (2, N'Joka', N'Joka', N'joka', N'12345678')
INSERT [dbo].[Radnik] ([RadnikID], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (3, N'Dragi', N'Dragi', N'dragi', N'12345678')
GO
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1015, 1, CAST(N'2026-03-19' AS Date), CAST(N'2026-03-19' AS Date), 62000, 63000, 500, 1000, N'zavrseno', 1)
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1015, 2, CAST(N'2026-03-19' AS Date), CAST(N'2026-03-21' AS Date), 255000, NULL, 30, 60, N'aktivno', 1029)
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1019, 1, CAST(N'2026-03-19' AS Date), CAST(N'2026-03-19' AS Date), 149999, 151000, 30, 60, N'zavrseno', 5)
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1019, 2, CAST(N'2026-03-19' AS Date), CAST(N'2026-03-19' AS Date), 245000, 250000, 30, 60, N'zavrseno', 1028)
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1021, 1, CAST(N'2026-03-20' AS Date), CAST(N'2026-03-20' AS Date), 63000, 64000, 500, 1000, N'zavrseno', 1)
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1021, 2, CAST(N'2026-03-20' AS Date), CAST(N'2026-03-22' AS Date), 278000, NULL, 70, 140, N'aktivno', 1031)
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1022, 1, CAST(N'2026-03-20' AS Date), CAST(N'2026-03-22' AS Date), 151000, NULL, 30, 60, N'aktivno', 5)
INSERT [dbo].[StavkaIznajmljivanja] ([IznajmljivanjeID], [RBr], [DatumOd], [DatumDo], [PocetnaKM], [ZavrsnaKM], [CenaPoDanu], [UkupnaCenaStavke], [StatusStavke], [AutomobilID]) VALUES (1023, 1, CAST(N'2026-03-20' AS Date), CAST(N'2026-03-22' AS Date), 54000, NULL, 300, 600, N'aktivno', 1020)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [unq_AUTO_RegBr]    Script Date: 20/03/2026 16:28:55 ******/
ALTER TABLE [dbo].[Automobil] ADD  CONSTRAINT [unq_AUTO_RegBr] UNIQUE NONCLUSTERED 
(
	[RegistarskiBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Automobil]  WITH CHECK ADD  CONSTRAINT [FK_Automobil_KlasaVozila] FOREIGN KEY([KlasaID])
REFERENCES [dbo].[KlasaVozila] ([KlasaID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Automobil] CHECK CONSTRAINT [FK_Automobil_KlasaVozila]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Korisnik]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Radnik] FOREIGN KEY([RadnikID])
REFERENCES [dbo].[Radnik] ([RadnikID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Radnik]
GO
ALTER TABLE [dbo].[Korisnik]  WITH CHECK ADD  CONSTRAINT [FK_Korisnik_Mesto] FOREIGN KEY([MestoID])
REFERENCES [dbo].[Mesto] ([MestoID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Korisnik] CHECK CONSTRAINT [FK_Korisnik_Mesto]
GO
ALTER TABLE [dbo].[StavkaIznajmljivanja]  WITH CHECK ADD  CONSTRAINT [FK_StavkaIznajmljivanja_Automobil] FOREIGN KEY([AutomobilID])
REFERENCES [dbo].[Automobil] ([AutomobilID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StavkaIznajmljivanja] CHECK CONSTRAINT [FK_StavkaIznajmljivanja_Automobil]
GO
ALTER TABLE [dbo].[StavkaIznajmljivanja]  WITH CHECK ADD  CONSTRAINT [FK_StavkaIznajmljivanja_Iznajmljivanje] FOREIGN KEY([IznajmljivanjeID])
REFERENCES [dbo].[Iznajmljivanje] ([IznajmljivanjeID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StavkaIznajmljivanja] CHECK CONSTRAINT [FK_StavkaIznajmljivanja_Iznajmljivanje]
GO
ALTER TABLE [dbo].[Automobil]  WITH CHECK ADD  CONSTRAINT [ck_Auto_Statuus] CHECK  (([status]='rashodovan' OR [status]='nedostupan' OR [status]='dostupan'))
GO
ALTER TABLE [dbo].[Automobil] CHECK CONSTRAINT [ck_Auto_Statuus]
GO
ALTER TABLE [dbo].[Automobil]  WITH CHECK ADD  CONSTRAINT [ck_godiste] CHECK  (([godiste]>(1900)))
GO
ALTER TABLE [dbo].[Automobil] CHECK CONSTRAINT [ck_godiste]
GO
ALTER TABLE [dbo].[Automobil]  WITH CHECK ADD  CONSTRAINT [CK_Kilometraza] CHECK  (([Kilometraza]>=(0)))
GO
ALTER TABLE [dbo].[Automobil] CHECK CONSTRAINT [CK_Kilometraza]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [CK_Popust] CHECK  (([popust]>=(0) AND [popust]<(100)))
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [CK_Popust]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [ck_status] CHECK  (([statusIznajmljivanja]='stornirano' OR [statusIznajmljivanja]='zavrseno' OR [statusIznajmljivanja]='aktivno'))
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [ck_status]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [CK_UkupnaCena] CHECK  (([UkupnaCena]>(0)))
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [CK_UkupnaCena]
GO
ALTER TABLE [dbo].[KlasaVozila]  WITH CHECK ADD  CONSTRAINT [ck_Klasa_Cena] CHECK  (([OsnovnaCenaPoDanu]>(0)))
GO
ALTER TABLE [dbo].[KlasaVozila] CHECK CONSTRAINT [ck_Klasa_Cena]
GO
ALTER TABLE [dbo].[Radnik]  WITH CHECK ADD  CONSTRAINT [CK_Radnik_Sifra] CHECK  ((len([Sifra])>=(8)))
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [CK_Radnik_Sifra]
GO
ALTER TABLE [dbo].[StavkaIznajmljivanja]  WITH CHECK ADD  CONSTRAINT [CK_StatusStavke] CHECK  (([statusStavke]='aktivno' OR [statusStavke]='zavrseno'))
GO
ALTER TABLE [dbo].[StavkaIznajmljivanja] CHECK CONSTRAINT [CK_StatusStavke]
GO

