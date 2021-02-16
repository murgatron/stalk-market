import React from 'react';
import { NavLink } from 'react-router-dom';

import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import clsx from 'clsx';
import { Divider, Drawer, IconButton, List } from '@material-ui/core';
import { appStyles } from '../../styles';
import Routes from '../../Routes';

export default function Sidebar(props: any) {
  const { open, handleDrawerClose } = props;
  const classes = appStyles();

  const activeRoute = (routeName: any) => {
    return props.location.pathname === routeName ? true : false;
  }

  return (
    <Drawer
      variant="permanent"
      classes={{
        paper: clsx(classes.drawerPaper, !open && classes.drawerPaperClose),
      }}
      open={open}
    >
      <div className={classes.toolbarIcon}>
        <IconButton onClick={handleDrawerClose}>
          <ChevronLeftIcon />
        </IconButton>
      </div>
      <Divider />
      <List>
        {Routes.map((prop, key) => {
          return (
            <NavLink to={prop.path} key={key} style={{ textDecoration: 'none' }}>
              <ListItem button selected={activeRoute(prop.path)} className={classes.listItemText}>
                <ListItemIcon style={{ color: 'FFE082' }}>
                  <prop.iconComponent />
                </ListItemIcon>
                <ListItemText primary={prop.sidebarName} />
              </ListItem>
            </NavLink>
          );
        })}
      </List>
    </Drawer>
  )
}