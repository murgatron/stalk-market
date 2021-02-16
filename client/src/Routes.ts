import DashboardIcon from '@material-ui/icons/Dashboard';
import BarChartIcon from '@material-ui/icons/BarChart';
import PublicIcon from '@material-ui/icons/Public';
import StoreIcon from '@material-ui/icons/Store';
import LocalFloristIcon from '@material-ui/icons/LocalFlorist';
import AllIslands from './pages/AllIslands';
import BuysAndSells from './pages/BuysAndSells';
import Dashboard from './pages/Dashboard';
import YourIsland from './pages/YourIsland';

const Routes = [
  {
    path: '/',
    sidebarName: 'Dashboard',
    iconComponent: DashboardIcon,
    component: Dashboard
  },
  {
    path: '/your-island',
    sidebarName: 'Your Island',
    iconComponent: LocalFloristIcon,
    component: YourIsland
  },
  {
    path: '/all-islands',
    sidebarName: 'All Islands',
    iconComponent: PublicIcon,
    component: AllIslands
  },
  {
    path: '/buys-and-sells',
    sidebarName: 'Buys & Sells',
    iconComponent: StoreIcon,
    component: BuysAndSells
  },
  {
    path: '/activity',
    sidebarName: 'Activity',
    iconComponent: BarChartIcon,
    component: BuysAndSells
  }
];

export default Routes;
