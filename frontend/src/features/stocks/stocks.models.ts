import { UUID } from "crypto";

export interface StockListResult {
  stocks: Array<StockListItem>;
}

export interface StockListItem {
  id: UUID;
  ticker: string;
  securityName: string;
}

export interface stockDetails {
  id: UUID;
  ticker: string;
  securityName: string;

  details: {
    betaScore: number;
    previousClose: number;
    open: number;
    dailyAverageVolume: number;
    monthlyAveragePrice: number;
    yearlyAveragePrice: number;
    monthlyHighPrice: number;
    monthlyLowPrice: number;
  };
}
