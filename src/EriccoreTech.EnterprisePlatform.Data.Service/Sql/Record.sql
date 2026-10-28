CREATE TABLE dbo.Record (
    RecordId UNIQUEIDENTIFIER NOT NULL,
    RecordType NVARCHAR(100) NOT NULL,
    Payload NVARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    CreatedBy NVARCHAR(100) NOT NULL CONSTRAINT DF_Record_CreatedBy DEFAULT (SUSER_SNAME()),
    ModifiedDate DATETIME2 NULL,
    ModifiedBy NVARCHAR(100) NULL,
    CONSTRAINT PK_Record PRIMARY KEY CLUSTERED (RecordId)
);
GO

CREATE PROCEDURE dbo.usp_INSERT_Record
    @RecordId UNIQUEIDENTIFIER,
    @RecordType NVARCHAR(100),
    @Payload NVARCHAR(MAX),
    @CreatedDate DATETIME2
AS
BEGIN
    SET NOCOUNT ON;

    -- idempotent: a retried insert of the same RecordId is a no-op
    IF NOT EXISTS (SELECT 1 FROM dbo.Record WHERE RecordId = @RecordId) BEGIN
        INSERT INTO dbo.Record (RecordId, RecordType, Payload, CreatedDate)
        VALUES (@RecordId, @RecordType, @Payload, @CreatedDate);
    END
END
GO

CREATE PROCEDURE dbo.usp_GET_Record
    @RecordId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT RecordId, RecordType, Payload, CreatedDate
    FROM dbo.Record
    WHERE RecordId = @RecordId;
END
GO
