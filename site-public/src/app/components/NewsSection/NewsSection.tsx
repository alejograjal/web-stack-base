export default function NewsSection() {
    const stories = [
        { title: 'October: Feature Season across the globe', image: '/news1.jpg' },
        { title: 'Indonesia: Exploring land and beyond', image: '/news2.jpg' },
        { title: 'Israel: From Jerusalem to the desert', image: '/news3.jpg' },
    ];

    return (
        <section id="news" className="py-10 px-4 md:px-12 bg-light scroll-mt-20">
            <h2 className="text-2xl md:text-3xl font-semibold mb-6">Latest News & Stories</h2>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                {stories.map((story, index) => (
                    <div key={index} className="rounded-2xl overflow-hidden shadow-md">
                        <img src={story.image} alt={story.title} className="w-full h-52 object-cover" />
                        <div className="p-4 bg-white">
                            <h3 className="text-base font-medium text-dark">{story.title}</h3>
                        </div>
                    </div>
                ))}
            </div>
        </section>
    );
}