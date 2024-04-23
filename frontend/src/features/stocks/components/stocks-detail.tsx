import DisplayField from "@/components/displayField";
import { Paper, styled } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import { UUID } from "crypto";
import React, { useEffect, useState } from "react";
import { useGetStockDetails } from "../stocks.hooks";

export default function StocksDetail(props: {
  className?: string;
  selectedStockId?: UUID;
}) {
  const { fetch, loading, error, stockDetail } = useGetStockDetails();

  useEffect(() => {
    if (!props.selectedStockId) {
      return;
    }

    fetch(props.selectedStockId);
  }, [props.selectedStockId]);

  const Item = styled(Paper)(({ theme }) => ({
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: "center",
    color: theme.palette.text.secondary,
  }));

  return (
    <div className={`${props.className} p-6 grow border`}>
      {!loading && props.selectedStockId && stockDetail && (
        <Grid container spacing={2}>
          <Grid xs={6}>
            <DisplayField
              label="Ticker"
              value={stockDetail.ticker}
            ></DisplayField>
          </Grid>
          <Grid xs={6}>
            <DisplayField
              label="Daily avg volume"
              value={stockDetail.details.dailyAverageVolume}
            ></DisplayField>
          </Grid>

          <Grid xs={6}>
            <DisplayField
              label="Security Name"
              value={stockDetail.securityName}
            ></DisplayField>
          </Grid>
          <Grid xs={6} className="mb-4">
            <DisplayField
              label="Beta"
              value={stockDetail.details.betaScore.toFixed(2)}
            ></DisplayField>
          </Grid>

          <Grid xs={6}>
            <DisplayField
              label="Previous close"
              value={stockDetail.details.previousClose.toFixed(2)}
            ></DisplayField>
          </Grid>
          <Grid xs={6}>
            <DisplayField
              label="Month avg"
              value={stockDetail.details.monthlyAveragePrice.toFixed(2)}
            ></DisplayField>
          </Grid>

          <Grid xs={6}>
            <DisplayField
              label="Open"
              value={stockDetail.details.open.toFixed(2)}
            ></DisplayField>
          </Grid>
          <Grid xs={6} className="mb-4">
            <DisplayField
              label="52 weeks avg"
              value={stockDetail.details.yearlyAveragePrice.toFixed(2)}
            ></DisplayField>
          </Grid>

          <Grid xs={6}>
            <DisplayField
              label="Month low"
              value={stockDetail.details.monthlyLowPrice.toFixed(2)}
            ></DisplayField>
          </Grid>
          <Grid xs={6}>
            <DisplayField
              label="Month high"
              value={stockDetail.details.monthlyHighPrice.toFixed(2)}
            ></DisplayField>
          </Grid>
        </Grid>
      )}
    </div>
  );
}
