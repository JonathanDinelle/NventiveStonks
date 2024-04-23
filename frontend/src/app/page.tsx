"use client";

import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";
import TabContext from "@mui/lab/TabContext";
import TabList from "@mui/lab/TabList";
import TabPanel from "@mui/lab/TabPanel";
import React from "react";
import StocksTab from "@/features/stocks/components/stocks-tab";

export default function Home() {
  const [value, setValue] = React.useState("1");

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setValue(newValue);
  };

  return (
    <main className="p-6">
      <Box
        sx={{
          width: "100%",
          typography: "body1",
          border: "1px solid black",
          padding: "1.5rem",
        }}
      >
        <TabContext value={value}>
          <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
            <TabList onChange={handleChange} aria-label="lab API tabs example">
              <Tab label="Place order" value="1" className="ml-auto" />
              <Tab label="Manage order" value="2" />
            </TabList>
          </Box>
          <TabPanel value="1">
            <StocksTab></StocksTab>
          </TabPanel>
          <TabPanel value="2">Not today son!</TabPanel>
        </TabContext>
      </Box>
    </main>
  );
}
