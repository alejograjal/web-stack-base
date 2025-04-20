import ContactForm from './ContactForm';
import EmailIcon from '@mui/icons-material/Email';
import PhoneIcon from '@mui/icons-material/Phone';
import { Box, Container, Typography } from '@mui/material';

const ContactSection = () => {
    return (
        <Box component="section" id="contact" bgcolor="white" py={10}>
            <Container maxWidth="sm">
                <Typography variant="h4" align="center" fontWeight={700} gutterBottom>
                    Contact Us
                </Typography>

                <Box mb={6} textAlign="center">
                    <Typography variant="subtitle1" fontWeight={600} gutterBottom>
                        Allan Mesen Sancho
                    </Typography>

                    <Box display="flex" justifyContent="center" alignItems="center" gap={1} mb={1}>
                        <EmailIcon />
                        <Typography component="a" href="mailto:manuelantonioexplorer@gmail.com">
                            manuelantonioexplorer@gmail.com
                        </Typography>
                    </Box>
                    <Box display="flex" justifyContent="center" alignItems="center" gap={1}>
                        <PhoneIcon />
                        <Typography component="a" href="tel:+50663459999">
                            +506 6345 9999
                        </Typography>
                    </Box>
                </Box>

                <ContactForm />
            </Container>
        </Box>
    );
}

export default ContactSection;
