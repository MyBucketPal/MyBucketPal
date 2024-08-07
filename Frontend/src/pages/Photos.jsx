import "./Photos.css";
import { Link } from "react-router-dom";

export default function Photos() {
    return (
        <div id="Photos">
		
			<h1>Enjoy you life! Find ideas! Share xp</h1>
			<Link to={"/homePage"}>
				<button>Back</button>
			</Link>
			
			<section>
				<article>
					<figure>
						<h2>Food</h2>
						<p>Barbecue party birthday with friends</p>
					</figure>
					<img alt src="/images/photos/barbecue.jpg" />
				</article>
				<article>
					<figure>
						<h2>Travel</h2>
						<p>See Niagara Falls</p>
					</figure>
					<img alt src="/images/photos/niagara-falls.jpg" />
				</article>
				<article>
					<figure>
						<h2>Travel</h2>
						<p>Finally see the Colosseum (Rome)</p>
					</figure>
					<img alt src="/images/photos/colosseum.jpg" />
				</article>
				<article>
					<figure>
						<h2>Learing</h2>
						<p>Learning how to chochet for my grandson</p>
					</figure>
					<img alt src="/images/photos/crochet.jpg" />
				</article>


				<article>
					<figure>
						<h2>Learning</h2>
						<p>Learn solving rubic cube</p>
					</figure>
					<img alt src="/images/photos/magic-cube.jpg" />
				</article>

				<article>
					<figure>
						<h2>Party</h2>
						<p>Going to a retro concert with friends</p>
					</figure>
					<img alt src="/images/photos/music.jpg" />
				</article>
					
					<article>
						<figure>
							<h2>Extreme sports</h2>
							<p>Try parachute</p>
						</figure>
					<img alt src="/images/photos/parachute.jpg" />
					</article>
				<article>
					<figure>
						<h2>Food</h2>
						<p>Eat sushi</p>
					</figure>
					<img alt src="/images/photos/sushi.jpg" />
				</article>
					
					
				</section>
			
					


					<svg width="0" height="0">
						<defs>
							<clipPath id="hexagono" clipPathUnits="objectBoundingBox">
								<polygon points=".25 0, .75 0, 1 .5, .75 1, .25 1, 0 .5" />
							</clipPath>
						</defs>
					</svg>
            
        </div>
    );
}
