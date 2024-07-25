import { useState } from 'react';

const TestPage = () => {
  const [responseData, setResponseData] = useState(null);
  const [error, setError] = useState(null);

  const fetchData = async () => {
    try {
      const response = await fetch('api/Plan/all', {
        method: 'GET',
        credentials: 'include',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (response.ok) {
        const data = await response.json();
        setResponseData(data);
        setError(null);
      } else {
        const errorText = await response.text();
        setError(`Error: ${response.status} - ${errorText}`);
        setResponseData(null);
      }
    } catch (err) {
      setError(`Fetch error: ${err.message}`);
      setResponseData(null);
    }
  };

  return (
    <div>
      <h1>Test Page</h1>
      <button onClick={fetchData}>Fetch Data</button>
      {responseData && (
        <div>
          <h2>Response Data:</h2>
          <pre>{JSON.stringify(responseData, null, 2)}</pre>
        </div>
      )}
      {error && (
        <div>
          <h2>Error:</h2>
          <pre>{error}</pre>
        </div>
      )}
    </div>
  );
};

export default TestPage;