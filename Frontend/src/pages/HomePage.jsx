import Login from './pages/Login';

export default function HomePage() {
  return (
  <div>
  <header className="header">
      <h1>
        <img src="https://s3-eu-west-1.amazonaws.com/ih-materials/uploads/ironhack-skydive-logo.png" alt="IronSkydive Logo" />
        IronSkydive
      </h1>
      <h2>Let the adventure begin</h2>
      <aside className="quote">
        <i>“The best experience of our lives”</i>
      </aside>
    </header>
    <Login/>
    </div>

  );
}