import { Box, Typography, Link as MuiLink } from '@mui/material';

export const MicrodataTouristAttraction = () => {
    return (
        <Box
            component="div"
            itemScope
            itemType="https://schema.org/TouristAttraction"
            sx={{ display: 'none' }}
        >
            <Typography component="h1" itemProp="name">
                Manuel Antonio Explorer
            </Typography>
            <Typography component="p" itemProp="description">
                Experience unforgettable tours and adventures in Manuel Antonio, Costa Rica.
            </Typography>
            <Typography component="p">
                Location:{' '}
                <Box
                    component="span"
                    itemScope
                    itemType="https://schema.org/PostalAddress"
                >
                    <Box component="span" itemProp="addressLocality" display="inline">
                        Manuel Antonio
                    </Box>
                    {', '}
                    <Box component="span" itemProp="addressCountry" display="inline">
                        Costa Rica
                    </Box>
                </Box>
            </Typography>
            <Typography component="p">
                Contact:{' '}
                <Box component="span" itemProp="telephone" display="inline">
                    +506 1234 5678
                </Box>
            </Typography>
            <MuiLink href="https://manuelantonioexplorer.com" itemProp="url">
                Visit our website
            </MuiLink>
        </Box>
    );
}
