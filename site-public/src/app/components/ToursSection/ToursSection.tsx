import { Rating } from '@mui/material';

export default function ToursSection() {
    const tours = [
        { title: 'Luxor & Aswan Tour', image: '/tour1.jpg', price: '$799', rating: 4 },
        { title: 'Amazon Rainforest Cruise', image: '/tour2.jpg', price: '$1299', rating: 5 },
        { title: 'Safari in Tanzania', image: '/tour3.jpg', price: '$999', rating: 4.5 },
    ];

    return (
        <section id="tours" className="py-10 px-4 md:px-12 scroll-mt-20">
            <h2 className="text-2xl md:text-3xl font-semibold mb-6">Top Tours & Packages</h2>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                {tours.map((tour, index) => (
                    <div key={index} className="rounded-2xl bg-white shadow-md overflow-hidden">
                        <img src={tour.image} alt={tour.title} className="w-full h-52 object-cover" />
                        <div className="p-4 space-y-2">
                            <h3 className="text-lg font-medium">{tour.title}</h3>
                            <p className="text-primary font-semibold">{tour.price}</p>
                            <Rating name={`rating-${index}`} value={tour.rating} precision={0.5} readOnly size="small" />
                        </div>
                    </div>
                ))}
            </div>
        </section>
    );
}