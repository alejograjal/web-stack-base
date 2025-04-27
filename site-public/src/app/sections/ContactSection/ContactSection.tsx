"use client";

import { motion } from 'framer-motion';
import ContactForm from './ContactForm';
import EmailIcon from '@mui/icons-material/Email';
import PhoneIcon from '@mui/icons-material/Phone';
import { Box, Container, Typography } from '@mui/material';

const ContactSection = () => {
    return (
        <Box id="contact" bgcolor="white" py={10}>
            <Container maxWidth="sm">
                <motion.div
                    initial={{ opacity: 0, y: 20 }}
                    whileInView={{ opacity: 1, y: 0 }}
                    transition={{ duration: 0.5 }}
                >
                    <Typography variant="h2" align="center" fontWeight={700} gutterBottom>
                        Contact Us
                    </Typography>
                </motion.div>

                <Box mb={6} textAlign="center">
                    <motion.div
                        initial={{ opacity: 0, y: 20 }}
                        whileInView={{ opacity: 1, y: 0 }}
                        transition={{ duration: 0.5, delay: 0.1 }}
                    >
                        <Typography variant="subtitle1" fontWeight={600} gutterBottom>
                            Allan Mesen Sancho
                        </Typography>
                    </motion.div>

                    <motion.div
                        initial={{ opacity: 0, y: 20 }}
                        whileInView={{ opacity: 1, y: 0 }}
                        transition={{ duration: 0.5, delay: 0.2 }}
                    >
                        <Box display="flex" justifyContent="center" alignItems="center" gap={1} mb={1}>
                            <EmailIcon />
                            <Typography component="a" href="mailto:manuelantonioexplorer@gmail.com">
                                manuelantonioexplorer@gmail.com
                            </Typography>
                        </Box>
                    </motion.div>

                    <motion.div
                        initial={{ opacity: 0, y: 20 }}
                        whileInView={{ opacity: 1, y: 0 }}
                        transition={{ duration: 0.5, delay: 0.3 }}
                    >
                        <Box display="flex" justifyContent="center" alignItems="center" gap={1}>
                            <PhoneIcon />
                            <Typography component="a" href="tel:+50663459999">
                                +506 6345 9999
                            </Typography>
                        </Box>
                    </motion.div>

                </Box>

                <motion.div
                    initial={{ opacity: 0, y: 20 }}
                    whileInView={{ opacity: 1, y: 0 }}
                    transition={{ duration: 0.5, delay: 0.4 }}
                >
                    <ContactForm />
                </motion.div>
            </Container>
        </Box>
    );
}

export default ContactSection;