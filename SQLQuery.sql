CREATE TABLE [dbo].[Attendance] (
    [Date]        DATE            DEFAULT (CONVERT([date],getdate())) NOT NULL,
    [UserId]      INT             NOT NULL,
    [Username]    NVARCHAR (100)  NOT NULL,
    [Gender]      NVARCHAR (10)   NOT NULL,
    [Age]         INT             NOT NULL,
    [EnterTime]   TIME (7)        NOT NULL,
    [ExitTime]    TIME (7)        NULL,
    [WorkedHours] AS              (datediff(minute,[EnterTime],[ExitTime])/(60.0)) PERSISTED,
    [ImageData]   VARBINARY (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Date] ASC, [UserId] ASC)
);


CREATE TABLE [dbo].[Users] (
    [UserId]   INT            NOT NULL,
    [UserName] NVARCHAR (100) NOT NULL,
    [Gender]   NVARCHAR (10)  NOT NULL,
    [Age]      INT            NOT NULL,
    [JoinDate] DATE           DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC)
);

CREATE TABLE [dbo].[UserFaceFeatures] (
    [FeatureId]   INT             IDENTITY (1, 1) NOT NULL,
    [UserId]      INT             NOT NULL,
    [FeatureData] VARBINARY (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([FeatureId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Holidays] (
    [Date]        DATE           NOT NULL,
    [HolidayName] NVARCHAR (100) NOT NULL
);

