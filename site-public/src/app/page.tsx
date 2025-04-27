import Footer from '@components/Footer/Footer';
import Header from '@components/Header/Header';
import { Snackbar } from '@components/Shared/Snackbar';
import HomeSection from '@sections/HomeSection/HomeSection';
import ToursSection from '@sections/ToursSection/ToursSection';
import ReviewsSection from '@sections/ReviewsSection/ReviewsSection';
import GallerySection from '@sections/GallerySection/GallerySection';
import ContactSection from '@sections/ContactSection/ContactSection';
import ExperienceSection from '@sections/ExperienceSection/ExperienceSection';
import FloatingWhatsAppButton from '@components/FloatingButtons/FloatingWhatsAppButton';
import { MicrodataTouristAttraction } from '@sections/Microdata/MicrodataTouristAttraction';

export default function Principal() {
  return (
    <>
      <Header />
      <main className="scroll-smooth">
        <MicrodataTouristAttraction />
        <Snackbar />
        <HomeSection />
        <ToursSection />
        <ExperienceSection />
        <ReviewsSection />
        <GallerySection />
        <ContactSection />
        <Footer />
      </main>
      <FloatingWhatsAppButton />
    </>
  );
}