import React from 'react';

const BlogCard = ({ blog }) => {
  // Generate a random Picsum image link for each blog
  const imageLink = `https://picsum.photos/200?random=${blog.id}`;

  return (
    <div className="blog-card">
      <div className="blog-card-image">
        <img src={imageLink} alt="Blog" />
      </div>
      <div className="blog-card-content">
        <h3>{blog.title}</h3>
        <p>{blog.content}</p>
      </div>
    </div>
  );
};

export default BlogCard;
