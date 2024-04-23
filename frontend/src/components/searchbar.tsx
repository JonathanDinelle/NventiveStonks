import { Divider, IconButton, InputBase, Paper } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import SearchIcon from "@mui/icons-material/Search";
import DirectionsIcon from "@mui/icons-material/Directions";

export default function Searchbar(props: {
  className?: string;
  placeholder: string;
  onTextChanged: (stockId: string) => void;
}) {
  return (
    <Paper
      component="form"
      sx={{ p: "2px 4px", display: "flex", alignItems: "center" }}
    >
      <span className="p-3">
        <SearchIcon />
      </span>
      
      <InputBase
        sx={{ ml: 1, flex: 1 }}
        placeholder={props.placeholder}
        onChange={(a) => props.onTextChanged(a.target.value)}
        inputProps={{ "aria-label": "search google maps" }}
      />
    </Paper>
  );
}
