GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 02/01/2010 17:27:47 ******/
IF NOT EXISTS(SELECT * FROM [dbo].[aspnet_Applications] WHERE [ApplicationId] = '8462f708-c6b4-4981-b5a4-1671c3e80d3d')
	INSERT [dbo].[aspnet_Applications] ([ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]) VALUES (N'/ShowOff/', N'/showoff/', N'8462f708-c6b4-4981-b5a4-1671c3e80d3d', NULL)
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 02/01/2010 17:27:47 ******/
IF NOT EXISTS(SELECT * FROM [dbo].[aspnet_Users] WHERE [UserId] = '8fe58851-86f8-4424-8b41-353bf59b1ffd')
	INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'8462f708-c6b4-4981-b5a4-1671c3e80d3d', N'8fe58851-86f8-4424-8b41-353bf59b1ffd', N'admin', N'admin', NULL, 0, CAST(0x00009D100169A973 AS DateTime))
GO

/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 02/01/2010 17:27:47 ******/
IF NOT EXISTS(SELECT * FROM [dbo].[aspnet_Membership] WHERE [UserId] = '8fe58851-86f8-4424-8b41-353bf59b1ffd')
	INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'8462f708-c6b4-4981-b5a4-1671c3e80d3d', N'8fe58851-86f8-4424-8b41-353bf59b1ffd', N'nID9SKYO3NKBC8Rup2TiBSzSCz8=', 1, N'jukll3BW45LBY1MQgX01Fw==', NULL, N'admin@showoff.com', N'admin@showoff.com', NULL, NULL, 1, 0, CAST(0x00009D1001695018 AS DateTime), CAST(0x00009D100169A973 AS DateTime), CAST(0x00009D1001695018 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
GO