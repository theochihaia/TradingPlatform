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