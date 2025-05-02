/* eslint-disable react/display-name */
import '@testing-library/jest-dom';
import Principal from '@app/page';
import { render, screen } from '@testing-library/react';

jest.mock('@components/Header/Header', () => () => <header>Header</header>);
jest.mock('@components/Footer/Footer', () => () => <footer>Footer</footer>);
jest.mock('@sections/HomeSection/HomeSection', () => () => <div>HomeSection</div>);
jest.mock('@sections/ToursSection/ToursSection', () => () => <div>ToursSection</div>);
jest.mock('@sections/ReviewsSection/ReviewsSection', () => () => <div>ReviewsSection</div>);
jest.mock('@sections/GallerySection/GallerySection', () => () => <div>GallerySection</div>);
jest.mock('@sections/ContactSection/ContactSection', () => () => <div>ContactSection</div>);
jest.mock('@sections/ExperienceSection/ExperienceSection', () => () => <div>ExperienceSection</div>);
jest.mock('@components/FloatingButtons/FloatingWhatsAppButton', () => () => <div>WhatsApp</div>);
jest.mock('@sections/Microdata/MicrodataTouristAttraction', () => () => <div>Microdata</div>);
jest.mock('@components/Shared/Snackbar', () => () => <div>Snackbar</div>);

describe('Principal page', () => {
    it('renders all major sections', () => {
        render(<Principal />);
        expect(screen.getByText('Header')).toBeInTheDocument();
        expect(screen.getByText('Footer')).toBeInTheDocument();
        expect(screen.getByText('HomeSection')).toBeInTheDocument();
        expect(screen.getByText('WhatsApp')).toBeInTheDocument();
    });
});