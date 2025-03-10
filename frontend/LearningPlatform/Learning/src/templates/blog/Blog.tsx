import * as React from 'react';
import CssBaseline from '@mui/material/CssBaseline';
import Container from '@mui/material/Container';
import AppTheme from '../createCourse/components/shared-theme/AppTheme';
import AppAppBar from './components/AppAppBar';
import MainContent from './components/MainContent';
import Footer from './components/Footer';
import { useCourses } from '../../hooks/useAuth';

export default function Blog(props: { disableCustomTheme?: boolean }) {


  return (
    <AppTheme {...props}>
      <CssBaseline enableColorScheme />

      <Container

        maxWidth="lg"
        component="main"
        sx={{ display: 'flex', flexDirection: 'column', my: 16, gap: 4, marginTop: 0 }}
      >
        <MainContent />
      </Container>
      <Footer />
    </AppTheme>
  );
}
