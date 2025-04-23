import { WhatsApp } from '@mui/icons-material';

const FloatingWhatsAppButton = () => {
    return (
        <a href="https://wa.me/50663459555?text=Hi!%20I'm%20interested%20in%20a%20tour%20with%20Manuel%20Antonio%20Explorer." target="_blank" rel="noopener noreferrer" className="fixed bottom-4 right-4 bg-green-500 hover:bg-green-600 text-white p-4 rounded-full shadow-lg transition-all duration-300" aria-label='Go to WhatsApp'>
            <WhatsApp fontSize="large" />
        </a>
    );
}

export default FloatingWhatsAppButton;