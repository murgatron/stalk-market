import { createMuiTheme, responsiveFontSizes } from "@material-ui/core/styles";

let theme = createMuiTheme({
  palette: {
    primary: {
      main: '#4CAF50',
      light: '#d1ffe2',
      dark: '#6acb80',
      contrastText: '#000'
    },
    secondary: {
      main: '#00BFA5',
      light: '#B0BEC5',
      dark: '#33691E',
      contrastText: '#000',
    },
    action: {
      hover: '#FFE082',
      selected: '#FFE082',
      focus: '#FFF'
    }
  },
});

theme = responsiveFontSizes(theme);

export default theme;

