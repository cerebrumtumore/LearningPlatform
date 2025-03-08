import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import AdbIcon from '@mui/icons-material/Adb';
import { useAuth, useRole } from '../../hooks/useAuth';
import { Link, useNavigate } from 'react-router-dom';
import { Stack } from '@mui/material';
import { useDispatch } from 'react-redux';
import { useAppDispatch } from '../../store/hooks';
import { logout } from '../../store/user/userSlice';
import { removeTokenFromLocalStorage } from '../../helpers/cookiesHelper';
import { toast } from 'react-toastify';

const pages = ['Products', 'Pricing', 'Blog'];
const settings = ['Profile', 'Account', 'Dashboard', 'Logout'];

function header() {
  const navigate = useNavigate()
  const dispath = useAppDispatch()
  const isAuth = useAuth()
  const hasRole = useRole()
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(null);

  const logoutHandler = () => {
    dispath(logout())
    removeTokenFromLocalStorage('token')
    toast.success('You logged out')
    navigate('/sign-in')
  }

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  return (
    <AppBar position="fixed" sx={{backgroundColor: '#070809'}} >
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          
          <Typography
            variant="h6"
            noWrap
            component="a"
            href="#app-bar-with-responsive-menu"
            sx={{
              mr: 2,
              display: { xs: 'none', md: 'flex' },
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            LearningPlatform
          </Typography>

          <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none'} }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
            
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'left',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'left',
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{ display: { xs: 'block', md: 'none'} }}
            >
              {<MenuItem  onClick={handleCloseNavMenu}>
                    <Typography sx={{ textAlign: 'center' }}>Profile</Typography>
                </MenuItem>}
                <MenuItem  onClick={handleCloseNavMenu}>
                    <Typography sx={{ textAlign: 'center' }}>Account</Typography>
                </MenuItem>
                <MenuItem  onClick={handleCloseNavMenu}>
                    <Typography sx={{ textAlign: 'center' }}>Dashboard</Typography>
                </MenuItem>
                <MenuItem  onClick={handleCloseNavMenu}>
                    <Typography sx={{ textAlign: 'center' }}>logout</Typography>
                </MenuItem>
            </Menu>
          </Box>
          <AdbIcon sx={{ display: { xs: 'flex', md: 'none' }, mr: 1 }} />
          <Typography
            variant="h5"
            noWrap
            component="a"
            href="#app-bar-with-responsive-menu"
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            LearningPlatform
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex', marginLeft:'250px' } }}>
              {hasRole == "AUTHOR" && (
                <Button onClick={handleCloseNavMenu} href='/createCourse'
              sx={{ my: 2, color: 'white', display: 'block' }}>
                Добавить курс
              </Button>)}
              <Button onClick={handleCloseNavMenu}
              sx={{ my: 2, color: 'white', display: 'block' }}>
                Посмотреть список курсов
              </Button>
              <Button onClick={handleCloseNavMenu}
              sx={{ my: 2, color: 'white', display: 'block' }}>
                Мои Курсы
              </Button>

          </Box>
          {isAuth && (
            <Box sx={{ flexGrow: 0 }}>
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
                </IconButton>
              </Tooltip>
              <Menu
                sx={{ mt: '45px' }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <MenuItem  onClick={handleCloseUserMenu}>
                    <Typography sx={{ textAlign: 'center' }}>Profile</Typography>
                </MenuItem>
                <MenuItem  onClick={handleCloseUserMenu}>
                    <Typography sx={{ textAlign: 'center' }}>Account</Typography>
                </MenuItem>
                <MenuItem  onClick={handleCloseUserMenu}>
                    <Typography sx={{ textAlign: 'center' }}>Dashboard</Typography>
                </MenuItem>
                <MenuItem  onClick={logoutHandler}>
                    <Typography sx={{ textAlign: 'center' }}>logout</Typography>
                </MenuItem>
              </Menu>
            </Box>
          )}

          {!isAuth && (
            <Stack direction="row" spacing={3}>
              <Button
            component={Link}
            to="/sign-up"
            sx={{width: "100px", backgroundColor: '#0f1113'}}
            variant="contained"
            
            >
            Sign up
          </Button>
          <Button
          component={Link}
          to="/sign-in"
          sx={{width: "100px", backgroundColor: '#0f1113'}}
          variant="contained"
          
          >
          Sign in
          </Button>
            </Stack>
          )}
        </Toolbar>
      </Container>
    </AppBar>
  );
}
export default header;
