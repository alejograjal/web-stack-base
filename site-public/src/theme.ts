import { createTheme } from '@mui/material/styles';

const theme = createTheme({
    typography: {
        h1: {
            fontWeight: 'bold',
            marginBottom: '0.5rem',
            fontSize: '2rem',
            '@media (min-width:900px)': {
                fontSize: '3.75rem',
            },
        },
        h2: {
            fontWeight: 'bold',
            marginBottom: '0.5rem',
            fontSize: '2rem',
            '@media (min-width:900px)': {
                fontSize: '2.5rem',
            },
        },
    },
    components: {
        MuiList: {
            styleOverrides: {
                root: {
                    listStyleType: 'disc',
                    paddingLeft: '1.5rem',
                },
            },
        },
        MuiListItem: {
            styleOverrides: {
                root: {
                    listStylePosition: 'outside',
                    display: 'list-item',
                },
            },
        },
    },
});

export default theme;