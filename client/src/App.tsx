import { AppBar, Avatar, Button, CssBaseline, IconButton, Toolbar, Typography } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import clsx from 'clsx';
import React from 'react';
import './App.css';
import Sidebar from './components/Sidebar/Sidebar';
import Routes from './Routes';
import EcoIcon from '@material-ui/icons/Eco';
import { appStyles } from './styles';
import { withRouter, Route, Switch } from 'react-router-dom';

function App(props: any) {
  const classes = appStyles();

  const [open, setOpen] = React.useState(true);
  const handleDrawerOpen = () => {
    setOpen(true);
  };
  const handleDrawerClose = () => {
    setOpen(false);
  };

  return (
    <div className="App">
      <div className={classes.root}>
        <CssBaseline />
        <AppBar position="absolute" className={clsx(classes.appBar, open && classes.appBarShift)}>
          <Toolbar className={classes.toolbar}>
            <IconButton
              edge="start"
              color="inherit"
              aria-label="open drawer"
              onClick={handleDrawerOpen}
              className={clsx(classes.menuButton, open && classes.menuButtonHidden)}
            >
              <MenuIcon />
            </IconButton>
            <Typography component="h1" variant="h6" style={{ color: '#fff' }} noWrap className={classes.title}>
              <EcoIcon /> Nook Stalk Exchange
            </Typography>
            <Button color="inherit" startIcon={<Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />}>
              username
               {/* TODO, profile, data entry */}
            </Button>
          </Toolbar>
        </AppBar>
        <Sidebar open={open} handleDrawerClose={handleDrawerClose} {...props} />
        <main className={classes.content}>
          <div className={classes.appBarSpacer} />
          <Switch>
            {Routes.map((route: any) => (
              <Route exact path={route.path} key={route.path}>
                <route.component />
              </Route>
            ))}
          </Switch>
        </main>
      </div>
    </div>
  );
}

export default withRouter(App);
