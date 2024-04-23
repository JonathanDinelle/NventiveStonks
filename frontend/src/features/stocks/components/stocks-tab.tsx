import Searchbar from "@/components/searchbar";
import StockList from "./stocks-list";
import StocksDetail from "./stocks-detail";
import { UUID } from "crypto";
import { useState } from "react";

export default function StocksTab(props: { className?: string }) {
  const [selectedStockId, setSelectedStockId] = useState<UUID | undefined>();
  const [searchValue, setSearchValue] = useState<string | undefined>();

  const handleStockSelected = (stockId: UUID) => {
    setSelectedStockId(stockId);
  };

  const handleTextChanged = (text: string) => {
    setSearchValue(text);
  }

  return (
    <>
      <Searchbar placeholder="Search" onTextChanged={(txt) => handleTextChanged(txt)}></Searchbar>
      <section className="flex my-4">
        <StockList onItemClick={(id) => handleStockSelected(id)} filter={searchValue}></StockList>
        <StocksDetail className="ml-4 w-1/2 min-w-1/2" selectedStockId={selectedStockId}></StocksDetail>
      </section>
    </>
  );
}
