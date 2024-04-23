import { List, ListItem, ListItemText } from "@mui/material";
import { useStockList } from "../stocks.hooks";
import React from "react";
import { UUID } from "crypto";
import { StockListItem } from "../stocks.models";

export default function StockList(props: {
  className?: string;
  filter?: string;
  onItemClick: (stockId: UUID) => void;
}) {
  const { loading, stockList } = useStockList();

  const shouldShowItem = (stock: StockListItem) => {
    if (!props.filter) {
      return true;
    }

    const lowerCaseSearchTerm = props.filter.toLowerCase();

    return (
      stock.securityName.toLowerCase().includes(lowerCaseSearchTerm) ||
      stock.ticker.toLowerCase().includes(lowerCaseSearchTerm)
    );
  };

  return (
    <>
      {loading ? null : (
        <List className="border">
          {Array.isArray(stockList) &&
            stockList
              .filter((item) => shouldShowItem(item))
              .map((stock, index) => (
                <ListItem key={index} className="cursor-pointer">
                  <ListItemText
                    onClick={() => props.onItemClick(stock.id)}
                    className="hover:bg-slate-100"
                    primary={`${stock.ticker} - ${stock.securityName}`}
                    key={stock.id}
                  />
                </ListItem>
              ))}
        </List>
      )}
    </>
  );
}
