-- Stored Procs

/*
	Stock
		GetStockDetail
		InsertStock
		UpdateStock
*/

/*
	TradingSession
		GetTradingSession(Symbol, StartDate, EndDate)
		InsertTradingSession(Symbol, TradingDate, Open Price, Close Price, High Price, Low Price, Volume)
		DeleteTradingSession(Symbol, StartDate, EndDate)
*/

/*
	Trade
		GetTrades(Symbol, StartDate, EndDate)
		InsertTrade(Symbol, TradingDate, TradePrice, TradeAmount, NumberOfShares)
		DeleteTrade(Symbol, StartDate, EndDate)
*/


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ins_CreatePortfolio')
BEGIN
DROP PROCEDURE ins_CreatePortfolio
END
GO

CREATE PROCEDURE ins_CreatePortfolio (
@PortfolioGUID UNIQUEIDENTIFIER,        -- Guid for portfolio
@PortfolioName VARCHAR (255),			-- Name of Portfolio
@Symbols VARCHAR (255),					-- Symbols this portfolio will process
@UserGUID UNIQUEIDENTIFIER		-- User of the Portfolio
)

AS
BEGIN
	INSERT INTO Portfolio( PortfolioGUID, PortfolioName, Symbols, UserID )
	SELECT
		@PortfolioGUID
		,@PortfolioName
		,@Symbols
		,(SELECT UserID FROM UserAccount WHERE UserGUID = @UserGUID)
END
GO


select * from Portfolio
