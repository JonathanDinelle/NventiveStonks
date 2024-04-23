import { getHttpClient } from "@/helpers/http.helper";
import { useEffect, useState } from "react";
import { StockListItem, StockListResult, stockDetails } from "./stocks.models";

export const useStockList = () => {
  const [stockList, setStockList] = useState<StockListItem[]>();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error | null>(null);

  useEffect(() => {
    async function fetch() {
      setLoading(true);
      const httpClient = getHttpClient(
        `${process.env.NEXT_PUBLIC_STOCKS_API_URL}`
      );
      try {
        setError(null);
        const response = await httpClient.get<StockListResult>("/api/stocks");
        setStockList(response.data.stocks);
      } catch (error: any) {
        setError(error);
      } finally {
        setLoading(false);
      }
    }
    fetch();
  }, []);

  return { stockList, loading, error, fetch };
};

export const useGetStockDetails = () => {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<Error | null>(null);
    const [stockDetail, setStockDetail] = useState<stockDetails>();

  
    async function fetch(id: string) {
        setLoading(true);
        const httpClient = getHttpClient(`${process.env.NEXT_PUBLIC_STOCKS_API_URL}`);
        try {
          setError(null);
          const response = await httpClient.get<stockDetails>(`/api/stocks/${id}`);
          setStockDetail(response.data);
        } catch (error: any) {
          setError(error);
        } finally {
          setLoading(false);
        }
      }
  
    return { stockDetail, loading, error, fetch };
  };
