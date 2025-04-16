export default function Footer() {
    return (
        <footer className="bg-[#101828] text-white py-10 px-4 md:px-12">
            <div className="max-w-7xl mx-auto grid grid-cols-1 md:grid-cols-4 gap-8">
                <div>
                    <h4 className="text-xl font-semibold mb-4">Wander</h4>
                    <p className="text-gray-400 text-sm">Discover story-worthy travel moments and join our global community of explorers.</p>
                </div>
                <div>
                    <h5 className="text-lg font-semibold mb-3">Company</h5>
                    <ul className="space-y-2 text-sm text-gray-300">
                        <li>About us</li>
                        <li>Careers</li>
                        <li>Contact</li>
                    </ul>
                </div>
                <div>
                    <h5 className="text-lg font-semibold mb-3">Support</h5>
                    <ul className="space-y-2 text-sm text-gray-300">
                        <li>Help Center</li>
                        <li>Terms of Service</li>
                        <li>Privacy Policy</li>
                    </ul>
                </div>
                <div>
                    <h5 className="text-lg font-semibold mb-3">Stay up to date</h5>
                    <input type="email" placeholder="Enter your email" className="w-full px-3 py-2 rounded-md bg-[#1F2A37] text-sm text-white placeholder-gray-400" />
                    <button className="mt-2 w-full bg-primary hover:bg-primary/90 text-white py-2 rounded-md text-sm font-semibold">Subscribe</button>
                </div>
            </div>
            <div className="mt-10 text-center text-gray-500 text-sm">
                &copy; {new Date().getFullYear()} Wander. All rights reserved.
            </div>
        </footer>
    );
}